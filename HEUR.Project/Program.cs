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
            double bestResult = 6000;
            while (true)
            {
                Result result = ResultGenerator.GAAlgorithm(bestResult);
                if (result.CannotFind==0 && result.IsValid())
                {
                    double energy = result.Energy();
                    if (energy < bestResult)
                    {
                        //PrintResult(result,energy+".txt");
                        bestResult = energy;

                        Console.WriteLine("Found better : "+bestResult);
                    }
                    //if (energy < 5000)
                    //{
                    //    PrintResult(result, energy + "_1.txt");
                    //}

                    
                }

            } 

        }

        private static void PrintResult(Result result, string filename)
        {
            using (StreamWriter writetext = new StreamWriter(filename))
            {
                writetext.WriteLine("x=[");
                
                for (int i = 0 ; i<result.x.GetLength(1);i++)
                {
                    String line = "[";
                    for (int j = 0; j < result.x.GetLength(0); j++)
                    {
                        line += result.x[j, i] + ",";
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
                    int[] comunicationNodes = route.comunicationNodes.Select(p => p + 1).ToArray();
                    routeLine ="<"+(route.componentOne+1)+","+(route.componentTwo+1)+",["+string.Join(",", comunicationNodes) +"]>,";

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
