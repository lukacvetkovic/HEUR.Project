using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEUR.Project
{
    public static class ResultGenerator
    {
        public static Result NaiveResult()
        {
            int cnt = 0;
            Result rez = new Result() { x = new int[InputParameters.numServers, InputParameters.numVms] };

            rez.x = new int[InputParameters.numServers, InputParameters.numVms];
            for (int i = 0; i < InputParameters.numVms; i++)
            {
                while (true)
                {
                    Random r = new Random();
                    int server = r.Next(0, InputParameters.numServers - 1); //for ints
                    int component = r.Next(0, InputParameters.numVms - 1);

                    if (rez.x[server, component] == 0)
                    {
                        rez.x[server, component] = 1;
                        if (!rez.IsValid())
                        {
                            rez.x[server, component] = 0;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            }

            Result result = makeRoutes(rez.x);

            return result;
        }

        public static Result TabuSearch(Result result)
        {
            throw new NotImplementedException();
        }

        private static Result makeRoutes(int[,] x)
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
    }
}
