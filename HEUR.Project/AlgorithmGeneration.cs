using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEUR.Project
{

    class AlgorithmGeneration
    {
        private static double uniformRate = 0.3;
        private static double mutationRate = 0.6;
        private static int tournamentSize = 5;
        private static bool elitism = true;

        public static Population evolvePopulation(Population pop)
        {

            Population newPopulation = new Population(pop.individuals.Count, false);

            // Keep our best individual
            if (elitism)
            {
                newPopulation.individuals.Insert(0, pop.GetFittest());
            }

            // Crossover population
            var elitismOffset = elitism ? 1 : 0;
            // Loop over the population size and create new individuals with
            // crossover
            for (int i = elitismOffset; i < pop.individuals.Count; i++)
            {
                Result indiv1 = TournamentSelection(pop);
                Result indiv2 = TournamentSelection(pop);
                Result newIndiv = Crossover(indiv1, indiv2);
                newPopulation.individuals.Add(newIndiv);
            }

            // Mutate population
            for (int i = elitismOffset; i < newPopulation.individuals.Count; i++)
            {
                newPopulation.individuals[i] = Mutate(newPopulation.individuals[i]);
            }

            return newPopulation;
        }

        // Crossover individuals
        private static Result Crossover(Result indiv1, Result indiv2)
        {
            Result newSol = new Result();
            Random random = new Random();
            // Loop through genes
            for (int i = 0; i < indiv1.x.GetLength(1); i++)
            {
                // Crossover
                if (random.NextDouble() <= uniformRate)
                {

                    int server1 = GetComponentServer(i, indiv1.x);
                    int server2 = GetComponentServer(i, indiv2.x);
                    int server = Math.Abs((server1 - server2) / 2);
                    newSol.x[server, i] = 1;
                }
                else
                {

                    if (random.NextDouble() <= 0.5)
                    {
                        int server = GetComponentServer(i, indiv1.x);
                        newSol.x[server, i] = 1;
                    }
                    else
                    {
                        int server = GetComponentServer(i, indiv2.x);
                        newSol.x[server, i] = 1;
                    }
                }
            }
            return newSol;
        }

        private static int GetComponentServer(int component, int[,] x)
        {
            int server = 0;
            for (int i = 0; i < x.GetLength(0); i++)
            {
                if (x[i, component] != 0)
                {
                    server = i;
                    break;
                }
            }

            return server;
        }

        // Mutate an individual
        private static Result Mutate(Result indiv)
        {
            Random random = new Random();
            // Loop through genes
            for (int i = 0; i < indiv.x.GetLength(1); i++)
            {
                if (random.NextDouble() <= mutationRate)
                {
                    // Create random gene
                    int serverOfComponent = GetComponentServer(i, indiv.x);
                    indiv.x[serverOfComponent, i] = 0;
                    int server = random.Next(0, InputParameters.numServers - 1);
                    indiv.x[server, i] = 1;

                }

            }
            return indiv.makeRoutes();
        }

        // Select individuals for crossover
        private static Result TournamentSelection(Population pop)
        {
            // Create a tournament population
            Population tournament = new Population(tournamentSize, false);
            // For each place in the tournament get a random individual
            Random random = new Random();
            for (int i = 0; i < tournamentSize; i++)
            {
                int randomId = random.Next(0, pop.individuals.Count - 1);
                tournament.individuals.Add(pop.individuals[randomId]);
            }
            // Get the fittest
            Result fittest = tournament.GetFittest();
            return fittest;
        }
    }
}
