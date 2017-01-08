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

        public double Energy()
        {
            if (IsValid())
            {
                return serverPower() + LinkAndNodePower();
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

            power += connections.Select(p => p.energyConsumption).Sum();


            foreach (var node in nodes)
            {
                power += InputParameters.P[node];
            }
            return power;
        }

        private double serverPower()
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
}
