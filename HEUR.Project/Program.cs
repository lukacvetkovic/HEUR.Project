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
            DateTime dt = DateTime.Now;
            DateTime twoHoues = dt.AddHours(2);
            do
            {
                Result result = ResultGenerator.NaiveResult();
                if (result.CannotFind==0 && result.IsValid())
                {

                    resultList.Add(result);
                    Console.WriteLine("NADENO RJESENJE " + (resultList.Count) +" Snaga : "+ result.Energy());

                    
                }

                //while (!result.IsValid())
                //{
                //    result = ResultGenerator.TabuSearch(result);
                //}

            } while (DateTime.Now <=twoHoues);

            int i = 0;
            foreach (var result in resultList.OrderBy(p=>p.Energy()).Take(10))
            {
                PrintResult(result, "Result_" + i + ".txt");
                i++;
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
