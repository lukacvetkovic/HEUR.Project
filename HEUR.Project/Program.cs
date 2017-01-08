using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace HEUR.Project
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Result> resultList = new List<Result>();
            do
            {
                Result result = ResultGenerator.NaiveResult();
                if (result.CannotFind==0)
                {
                    Console.WriteLine("NADENO RJESENJE "+ resultList.Count + 1);
                    resultList.Add(result);

                    PrintResult(result, "Result_"+resultList.Count+1+".txt");
                }

                //while (!result.IsValid())
                //{
                //    result = ResultGenerator.TabuSearch(result);
                //}

            } while (resultList.Count<=10);
        }

        private static void PrintResult(Result result, string filename)
        {
            using (StreamWriter writetext = new StreamWriter(filename))
            {
                writetext.WriteLine("x=[");
                
                for (int i = 0 ; i<result.x.GetLength(0);i++)
                {
                    String line = "[";
                    for (int j = 0; j < result.x.GetLength(1); j++)
                    {
                        line += result.x[i, j] + ",";
                    }

                    line = line.Remove(line.Length - 1, 1) + "]";

                    writetext.WriteLine(line);
                }

                writetext.WriteLine("];");

                writetext.WriteLine();

                writetext.WriteLine("routes={");

                String routeLine = "";
                foreach (var route in result.routes)
                {
                    routeLine="<"+route.componentOne+","+route.componentTwo+",["+string.Join(",", route.comunicationNodes) +"]>,";

                    if (result.routes.Last() == route)
                    {
                        routeLine = routeLine.Remove(routeLine.Length - 1, 1);
                    }

                    writetext.WriteLine(routeLine);
                }


                writetext.WriteLine("};");
            }
        }
    }
}
