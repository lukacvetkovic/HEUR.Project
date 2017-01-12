using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEUR.Project
{
    public class Population
    {
        public List<Result> individuals;

        public Population(int populationSize, bool initialise)
        {
            individuals = new List<Result>();

            if (initialise)
            {
                for (int i = 0; i < populationSize; i++)
                {
                    Result r = ResultGenerator.NaiveResult();

                    individuals.Add(r.MakeRoutes());
                }
            }
        }

        public Result GetFittest()
        {
            return individuals.OrderBy(p => p.Energy()).First();
        }
    }
}
