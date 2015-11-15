using System;
using System.Collections.Generic;
using MoreLinq;
using System.Linq;

namespace GraphDisplay
{
    public class EvolutionMgr
    {
        public int popSize { get; set; }
        private int evolvePopSize;
        public int iterations { get; set; }
        public double mutationRate { get; set; }
        public double crossoverRate { get; set; }
        private List<MLP> mlps;
        private string file;
        private int minWeight;
        private int maxWeight;
        private bool evolveWeights;
        private bool evolveFunction;
        Random r = new Random();
        PerfGraph graph;

        public EvolutionMgr(PerfGraph graph, string file, bool evolveWeights, bool evolveFunction, int popSize, int iterations, double mutationRate, double crossoverRate, int minWeight, int maxWeight)
        {
            this.file = file;
            this.popSize = popSize;
            this.iterations = iterations;
            this.mutationRate = mutationRate;
            this.crossoverRate = crossoverRate;
            this.minWeight = minWeight;
            this.maxWeight = maxWeight;
            this.evolveFunction = evolveFunction;
            this.evolveWeights = evolveWeights;
            this.graph = graph;
            initMLP();
            calculatePopToEvolve();
            
        }

        private void initMLP()
        {
            mlps = new List<MLP>();
            for(int i = 0; i<popSize; i++)
            {
                mlps.Add(new MLP(graph, file, minWeight, maxWeight));
                System.Threading.Thread.Sleep(20);
            }
            Console.WriteLine("done");
        }

        private void calculatePopToEvolve()
        {
            evolvePopSize = (popSize / 6) * 2;
        }

        public void run()
        {
            int iteration = 0;
            while (iteration < iterations)
            {
                double[] fitness = new double[mlps.Count];
                //double[,] outputs = 
                int i = 0;
                foreach (MLP mlp in mlps)
                {
                    mlp.run(50);
                    fitness[i] = mlp.meanSquaredError();
                    mlp.resetMLP();
                    i++;
                }
                bool converged = true;
                double minSquaredError = 9999;
                foreach(double error in fitness)
                {
                    if (error < minSquaredError)
                    {
                        minSquaredError = error;
                    }
                    if (error != fitness[0])
                    {
                        converged = false;
                    }
                }

                if (converged)
                {
                    Console.WriteLine("CONVERGED after :" +iteration+ " iterations");
                    break;
                }
                //get the top and bottom population
                List<KeyValuePair<double, MLP>> evolvingMLP = new List<KeyValuePair<double, MLP>>();
                List<KeyValuePair<double, MLP>> removingMLP = new List<KeyValuePair<double, MLP>>();
                for (i = 0; i < evolvePopSize; i++)
                {
                    evolvingMLP.Add(new KeyValuePair<double, MLP>(fitness[i], mlps[i]));
                    removingMLP.Add(new KeyValuePair<double, MLP>(fitness[i], mlps[i]));
                }
                for (i = evolvePopSize; i < popSize; i++)
                {
                    var maxBestFitness = evolvingMLP.MaxBy(kvp => kvp.Key).Key;
                    var maxBestFitnessPair = evolvingMLP.MaxBy(kvp => kvp.Key);
                    var minWorstFitness = removingMLP.MinBy(kpv => kpv.Key).Key;
                    var minWorstFitnessPair = removingMLP.MinBy(kpv => kpv.Key);
                    if (fitness[i] < maxBestFitness)
                    {
                        evolvingMLP.Remove(maxBestFitnessPair);
                        evolvingMLP.Add(new KeyValuePair<double,MLP>(fitness[i], mlps[i]));
                    }
                    if (fitness[i] > minWorstFitness)
                    {
                        removingMLP.Remove(minWorstFitnessPair);
                        removingMLP.Add(new KeyValuePair<double, MLP>(fitness[i], mlps[i]));
                    }
                }
                //evolve the top population
                List<MLP> temp = new List<MLP>();
                foreach(KeyValuePair<double, MLP> kvp in removingMLP)
                {
                    temp.Add(kvp.Value);
                }
                //remove the population with the bottom fitness
                foreach (MLP m in temp)
                {
                    mlps.Remove(m);
                }
                temp.Clear();
                foreach (KeyValuePair<double, MLP> kvp in evolvingMLP)
                {
                    temp.Add(kvp.Value);
                }
                //add the evolved mlps to the population
                List<MLP> evolved = evolvePop(temp);
                foreach (MLP m in evolved)
                {
                    mlps.Add(m);
                }
                iteration++;
            }
        }

        private List<MLP> evolvePop(List<MLP> population)
        {
            MLP m1;
            MLP m2;
            int index;
            List<MLP> newPop = new List<MLP>();
            while (population.Count > 0)
            {
                index = r.Next(0, population.Count);
                m1 = population[index];
                population.RemoveAt(index);
                index = r.Next(0, population.Count);
                m2 = population[index];
                population.RemoveAt(index);
                doCrossover(m1, m2, out m1, out m2);
                doMutation(m1, out m1);
                doMutation(m2, out m2);
                newPop.Add(m1);
                newPop.Add(m2);
            }
            return newPop;

        }

        private void doCrossover(MLP m1, MLP m2, out MLP m1Out, out MLP m2Out)
        {
            double probability = r.NextDouble();
            if (probability <= crossoverRate)
            {
                if (evolveWeights)
                {
                    int nodeIndex = r.Next(0, 5);
                    //test swap
                    Node n = m1.nodes[nodeIndex];
                    m1.nodes[nodeIndex] = m2.nodes[nodeIndex];
                    m2.nodes[nodeIndex] = n;
                    double weight = m1.getWeight(nodeIndex);
                    m1.setWeight(nodeIndex, m2.getWeight(nodeIndex));
                    m1.setWeight(nodeIndex, weight);
                    int nodeIndex2 = r.Next(0, 5);
                    while (nodeIndex2 == nodeIndex)
                    {
                        nodeIndex2 = r.Next(0, 5);
                    }
                    nodeIndex = nodeIndex2;
                    //test swap
                    n = m1.nodes[nodeIndex];
                    m1.nodes[nodeIndex] = m2.nodes[nodeIndex];
                    m2.nodes[nodeIndex] = n;
                    weight = m1.getWeight(nodeIndex);
                    m1.setWeight(nodeIndex, m2.getWeight(nodeIndex));
                    m1.setWeight(nodeIndex, weight);
                }
                if(evolveFunction)
                {
                    MLP.Activation a = m1.activation;
                    m1.activation = m2.activation;
                    m2.activation = a;
                }

            }
            m1Out = m1;
            m2Out = m2;
        }

        private void doMutation(MLP m, out MLP mOut)
        {
            double probability = r.NextDouble();
            if (probability <= mutationRate)
            {
                if (evolveWeights)
                {
                    m.mutateWeights();
                }
                if(evolveFunction)
                {
                    m.mutateFunction();
                }
            }
            mOut = m;
        }
    }

}
