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
            return CheckResource();
            //return (CheckResource() && CheckLinkConstraints() && CheckLatency());
        }

        private bool CheckResource()
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
                        p => p.componentOne == route.componentOne && p.componentTwo == route.componentTwo).bandwith;
                for (int k = 0; k < route.comunicationNodes.Count - 1; k++)
                {
                    NodeConnection conn =
                        nodeConnections.SingleOrDefault(
                            p =>
                                p.firstNode == route.comunicationNodes[k] &&
                                p.secondNode == route.comunicationNodes[k + 1]);
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
                    if (r != null)
                    {
                        for (int k = 0; k < r.comunicationNodes.Count - 1; k++)
                        {
                            NodeConnection conn =
                                InputParameters.Edges.SingleOrDefault(
                                    p =>
                                        p.firstNode == r.comunicationNodes[k] &&
                                        p.secondNode == r.comunicationNodes[k + 1]);
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
                    else
                    {
                        return false;
                    }
                }

                if (computedLatency > maxLatency)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
