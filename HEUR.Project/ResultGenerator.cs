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
            throw new NotImplementedException();
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

            List<Route> routeList= new List<Route>();
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

                for (int j = 0; j < components.Count-1; j++)
                {
                    Route r = findRouteForComponents(components[j], components[j + 1], nodeConnections, x);
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

            return new Result {routes = routeList,x = x,CannotFind = cannotFind};
            

        }

        private static Route findRouteForComponents(int componentStart, int componentEnd, List<NodeConnection> nodeConnections, int[,] x)
        {
            int serverStart=0;
            int serverEnd=0;
            int nodeStart=0;
            int nodeEnd=0;

            for (int i = 0; i < x.GetLength(0);i++)
            {
                if (x[i, componentStart] != 0)
                {
                    serverStart = i;
                    break;
                }
            }

            for (int i = 0; i < x.GetLength(0); i++)
            {
                if (x[i, componentEnd] != 0)
                {
                    serverEnd = i;
                    break;
                }
            }

            for(int i = 0; i < InputParameters.al.GetLength(1); i++)
            {
                if (InputParameters.al[serverStart, i] != 0)
                {
                    nodeStart = i;
                    break;
                }

            }

            for (int i = 0; i < InputParameters.al.GetLength(1); i++)
            {
                if (InputParameters.al[serverEnd, i] != 0)
                {
                    nodeEnd = i;
                    break;
                }

            }


            throw new NotImplementedException();

        }
    }
}
