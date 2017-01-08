using System;
using System.Collections.Generic;
using System.Linq;
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
                    Console.WriteLine("NADENO RJESENJE WOHOOO");
                    resultList.Add(result);
                }

                //while (!result.IsValid())
                //{
                //    result = ResultGenerator.TabuSearch(result);
                //}

            } while (resultList.Count<=10);
        }
    }
}
