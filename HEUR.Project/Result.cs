using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEUR.Project
{
    public class Result
    {
        public int[,] x;
        public List<Route> routes;
        public int CannotFind { get; set; }

        public Result()
        {
            x = new int[InputParameters.numServers, InputParameters.numVms];
            routes = new List<Route>();
        }
        #region Routes
        public Result makeRoutes()
        {
            List<NodeConnection> nodeConnections = new List<NodeConnection>();
            foreach (var connection in InputParameters.Edges)
            {
                nodeConnections.Add(new NodeConnection(connection.firstNode, connection.secondNode, connection.capacity, 0, 0));
            }

            List<Route> routeList = new List<Route>();
            int cannotFind = 0;
            for (int i = 0; i < InputParameters.sc.GetLength(0); i++)
            {
                List<int> components = new List<int>();
                for (int j = 0; j < InputParameters.sc.GetLength(1); j++)
                {
                    if (InputParameters.sc[i, j] != 0)
                    {
                        components.Add(j);
                    }
                }

                for (int j = 0; j < components.Count - 1; j++)
                {
                    Route r =
                        routeList.SingleOrDefault(p => p.componentOne == components[j] && p.componentTwo == components[j + 1]);
                    if (r == null)
                    {
                        r = findRouteForComponents(components[j], components[j + 1], nodeConnections, x);
                        if (r != null)
                        {
                            routeList.Add(r);
                        }
                        else
                        {
                            cannotFind++;
                        }
                    }
                }
            }

            return new Result { routes = routeList, x = x, CannotFind = cannotFind };


        }

        private static Route findRouteForComponents(int componentStart, int componentEnd, List<NodeConnection> nodeConnections, int[,] x)
        {
            int nodeStart = getComponentNode(componentStart, x);
            int nodeEnd = getComponentNode(componentEnd, x);

            Queue<Route> q = new Queue<Route>();


            q.Enqueue(new Route() { componentOne = componentStart, componentTwo = componentEnd, comunicationNodes = new List<int>() { nodeStart }, nodeConnections = new List<NodeConnection>(nodeConnections) });

            while (q.Count != 0)
            {
                Route r = q.Dequeue();
                int node = r.comunicationNodes.Last();

                if (node == nodeEnd)
                {
                    nodeConnections = r.nodeConnections;
                    return r;
                }

                int[] nexts = getNextNodes(r.comunicationNodes.Last());

                foreach (var next in nexts.Select(p => p - 1))
                {
                    Route newRoute = new Route() { comunicationNodes = new List<int>(r.comunicationNodes), nodeConnections = new List<NodeConnection>(r.nodeConnections), componentTwo = r.componentTwo, componentOne = r.componentOne };

                    if (newRoute.comunicationNodes.Contains(next))
                    {
                        continue;
                    }

                    var comunication = newRoute.nodeConnections.SingleOrDefault(
                            p => p.firstNode == newRoute.comunicationNodes.Last() + 1 && p.secondNode == next + 1);

                    comunication.capacity -=
                        InputParameters.VmDemands.SingleOrDefault(
                            p => p.componentOne == componentStart + 1 && p.componentTwo == componentEnd + 1).bandwith;

                    if (comunication.capacity >= 0)
                    {
                        newRoute.comunicationNodes.Add(next);

                        q.Enqueue(newRoute);
                    }
                }

            }


            return null;

        }

        private static int[] getNextNodes(int start)
        {
            return InputParameters.Edges.Where(p => p.firstNode == start + 1).Select(r => r.secondNode).ToArray();
        }

        private static int getComponentNode(int component, int[,] x)
        {
            int server = 0;
            int node = 0;
            for (int i = 0; i < x.GetLength(0); i++)
            {
                if (x[i, component] != 0)
                {
                    server = i;
                    break;
                }
            }


            for (int i = 0; i < InputParameters.al.GetLength(1); i++)
            {
                if (InputParameters.al[server, i] != 0)
                {
                    node = i;
                    break;
                }

            }

            return node;
        }
        #endregion

        public bool IsValid()
        {

            return (CheckResource() && CheckLinkConstraints() && CheckLatency());
        }

        #region Checkers
        public bool CheckResource()
        {
            for (int i = 0; i < x.GetLength(0); i++)
            {
                Double CPUOnServer = InputParameters.av[0, i];
                Double MEMOnServer = InputParameters.av[1, i];
                List<double> CPU = new List<double>();
                List<double> MEM = new List<double>();
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if (x[i, j] != 0)
                    {
                        CPU.Add(InputParameters.req[0, j]);
                        MEM.Add(InputParameters.req[1, j]);
                    }
                }

                Double SumCPU = CPU.Sum();
                Double SumMEM = MEM.Sum();

                if (SumCPU > CPUOnServer)
                {
                    return false;
                }

                if (SumMEM > MEMOnServer)
                {
                    return false;
                }

            }

            return true;
        }


        private bool CheckLinkConstraints()
        {
            List<NodeConnection> nodeConnections = new List<NodeConnection>();
            foreach (var connection in InputParameters.Edges)
            {
                nodeConnections.Add(new NodeConnection(connection.firstNode, connection.secondNode, connection.capacity, 0, 0));
            }
            foreach (var route in routes)
            {
                int VmDemand =
                    InputParameters.VmDemands.SingleOrDefault(
                        p => p.componentOne == route.componentOne + 1 && p.componentTwo == route.componentTwo + 1).bandwith;
                for (int k = 0; k < route.comunicationNodes.Count - 1; k++)
                {
                    NodeConnection conn =
                        nodeConnections.SingleOrDefault(
                            p =>
                                p.firstNode == route.comunicationNodes[k] + 1 &&
                                p.secondNode == route.comunicationNodes[k + 1] + 1);
                    conn.capacity -= VmDemand;
                }
            }

            int cnt = nodeConnections.Count(p => p.capacity < 0);

            if (cnt > 0)
            {
                return false;
            }

            return true;
        }

        private bool CheckLatency()
        {
            for (int i = 0; i < InputParameters.sc.GetLength(0); i++)
            {
                double maxLatency = InputParameters.lat[i];

                List<int> chain = new List<int>();

                for (int j = 0; j < InputParameters.sc.GetLength(1); j++)
                {
                    if (InputParameters.sc[i, j] != 0)
                    {
                        chain.Add(j);
                    }
                }

                double computedLatency = 0;
                for (int j = 0; j < chain.Count - 1; j++)
                {
                    Route r = routes.SingleOrDefault(p => p.componentOne == chain[j] && p.componentTwo == chain[j + 1]);

                    for (int k = 0; k < r.comunicationNodes.Count - 1; k++)
                    {
                        NodeConnection conn =
                            InputParameters.Edges.SingleOrDefault(
                                p =>
                                    p.firstNode == r.comunicationNodes[k] + 1 &&
                                    p.secondNode == r.comunicationNodes[k + 1] + 1);
                        if (conn != null)
                        {
                            computedLatency += conn.latency;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }

                if (computedLatency > maxLatency)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Energy
        public double Energy()
        {
            if (CannotFind == 0 && IsValid())
            {
                double serverPower = ServerPower();
                double linkPower = LinkAndNodePower();
                return serverPower + linkPower;
            }
            return 10000;
        }

        private double LinkAndNodePower()
        {
            double power = 0;

            HashSet<int> nodes = new HashSet<int>();
            HashSet<NodeConnection> connections = new HashSet<NodeConnection>();

            foreach (var route in routes)
            {
                if (route.comunicationNodes.Count != 0)
                {
                    foreach (var node in route.comunicationNodes)
                    {
                        nodes.Add(node);
                    }

                    for (int i = 0; i < route.comunicationNodes.Count - 1; i++)
                    {
                        var connection =
                            InputParameters.Edges.SingleOrDefault(
                                p =>
                                    p.firstNode == route.comunicationNodes[i] + 1 &&
                                    p.secondNode == route.comunicationNodes[i + 1] + 1);

                        connections.Add(connection);
                    }
                }
            }

            power += connections.Select(p => p.energyConsumption).Sum();


            foreach (var node in nodes)
            {
                power += InputParameters.P[node];
            }
            return power;
        }

        private double ServerPower()
        {
            double serverPower = 0;

            for (int i = 0; i < x.GetLength(0); i++)
            {
                bool active = false;
                for (int j = 0; j < x.GetLength(1); j++)
                {
                    if (x[i, j] != 0)
                    {
                        active = true;
                        break;
                    }
                }

                if (active)
                {
                    serverPower += InputParameters.P_min[i];
                    double CPUOnServer = InputParameters.av[0, i];
                    List<double> CPU = new List<double>();
                    for (int j = 0; j < x.GetLength(1); j++)
                    {
                        if (x[i, j] != 0)
                        {
                            CPU.Add(InputParameters.req[0, j]);

                        }
                    }

                    double SumCPU = CPU.Sum();

                    double value = (SumCPU / CPUOnServer) * (InputParameters.P_max[i] - InputParameters.P_min[i]);

                    serverPower += value;
                }

            }

            return serverPower;

        }
    }
    #endregion
}
