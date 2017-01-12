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
            Random r = new Random();

            rez.x = new int[InputParameters.numServers, InputParameters.numVms];
            for (int i = 0; i < InputParameters.numVms; i++)
            {
                while (true)
                {

                    int server = r.Next(0, InputParameters.numServers - 1);

                    if (rez.x[server, i] == 0)
                    {
                        rez.x[server, i] = 1;
                        if (!rez.CheckResource())
                        {
                            rez.x[server, i] = 0;
                        }
                        else
                        {
                            break;
                        }
                    }
                }

            }

            Result result = rez.makeRoutes();

            return result;
        }

        public static Result GAAlgorithm(double minEnergy)
        {
            Population population = new Population(15, true);

            int generationCount = 0;

            while (population.GetFittest().Energy()>minEnergy)
            {
                generationCount++;
                Console.WriteLine("Generation: " + generationCount + " Fittest : " + population.GetFittest().Energy());
                population = AlgorithmGeneration.evolvePopulation(population);
            }

            return population.GetFittest();
        }


    }
}
