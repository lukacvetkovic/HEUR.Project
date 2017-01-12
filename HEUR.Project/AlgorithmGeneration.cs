using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HEUR.Project
{

    class AlgorithmGeneration
    {
        private static double mutationRate = 0.02;
        private static int tournamentSize = 5;
        private static bool elitism = true;

        public static Population EvolvePopulation(Population pop)
        {

            Population newPopulation = new Population(pop.individuals.Count, false);

            // Keep our best individual
            if (elitism)
            {
                newPopulation.individuals.Add(pop.GetFittest());
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
            // Loop through genes
            for (int i = 0; i < indiv1.X.GetLength(1); i++)
            {
                double energyFirst = indiv1.Energy();
                double energySecond = indiv2.Energy();
                double fitnessSum = energyFirst + energySecond;
                if (GetRandomNumber(0, fitnessSum) > energyFirst)
                {
                    int firstServer = GetComponentServer(i, indiv1.X);
                    newSol.X[firstServer, i] = 1;
                }
                else
                {
                    int secondServer = GetComponentServer(i, indiv2.X);
                    newSol.X[secondServer, i] = 1;
                }
            }
            return newSol;
        }

        private static double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new Random();
            return random.NextDouble() * (maximum - minimum) + minimum;
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
            for (int i = 0; i < indiv.X.GetLength(1); i++)
            {
                if (random.NextDouble() <= mutationRate)
                {
                    // Create random gene
                    int serverOfComponent = GetComponentServer(i, indiv.X);
                    indiv.X[serverOfComponent, i] = 0;
                    int server = random.Next(0, InputParameters.numServers - 1);
                    indiv.X[server, i] = 1;

                }

            }
            return indiv.MakeRoutes();
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
