﻿using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace BIC_CW2
{
    public class MLP
    {
        List<Input> inputs;
        List<Node> nodes;
        private int MIN_WEIGHT_INTERVAL = -5;
        private int MAX_WEIGHT_INTERVAL = 5;
        private int HIDDEN_NODES_NO = 5;
        private int INPUT_NO;
        private double LEARNING_CONSTANT = 0.05;
        private double MOMENTUM = 0.5;
        private enum Activation {nullA, sigmoid, tangent, cos, gaussian};
        private Activation activation;
        private Random rand = new Random();

        public void initNodes()
        {
            nodes = new List<Node>();
            for(int i = 0; i < HIDDEN_NODES_NO; i++)
            {
                nodes.Add(new Node(randomWeights(INPUT_NO), INPUT_NO));
            }
        }
        public void initInput(int inputNo, String file)
        {
            inputs = new List<Input>();
            INPUT_NO = inputNo;
            using (FileStream reader = File.OpenRead(file))
            using (TextFieldParser parser = new TextFieldParser(reader))
            {
                parser.TrimWhiteSpace = false;
                //different delimiters to work with varying formatting of the files
                parser.Delimiters = new[] {"         ","\t", "    ", "   ", " " };
                parser.HasFieldsEnclosedInQuotes = true;
                Input inp = new Input();
                while (!parser.EndOfData)
                {
                    String[] line = parser.ReadFields();
                    //because of formatting sometimes the first element is an empty string so we need to remove it
                    if (line[0] == "")
                    {
                        for(int i = 0; i < line.Length - 1; i ++)
                        {
                            line[i] = line[i + 1];
                        }
                    }
                    if (INPUT_NO == 1)
                    {
                        inp = new Input(Convert.ToDouble(line[0]), Convert.ToDouble(line[1]));
                        inputs.Add(inp);
                    }
                    else
                    {
                        inp = new Input(Convert.ToDouble(line[0]), Convert.ToDouble(line[1]), Convert.ToDouble(line[2]));
                        inputs.Add(inp);
                    }
                }
                inp.setWeights(randomWeights(HIDDEN_NODES_NO));
                inp.initWeightChanges(HIDDEN_NODES_NO);
                Console.WriteLine("Got Inputs");
            }
        }

        public MLP(String file, int minWeight, int maxWeight)
        {
            initWeightIntervals(minWeight, maxWeight);
            initInput(1, "..\\..\\"+file+".txt");
            initNodes();
            activation = Activation.gaussian;
            run(1000, 200);
            Console.WriteLine("done");
        }

        //---------MAIN LOOP-------------------//

        private void run(int popSize, int iterations)
        {
            for(int i = 0; i < iterations; i ++)
            {
                bool done = true;
                for(int j = 0; (j<inputs.Count && j < popSize); j++)
                {
                    setNodeOutputs(j);
                    setOutput(j);

                    setOutputError(j);
                    setNodeErrors(j);

                    changeOutputWeights(j);
                    changeInputWeights(j);
                    //Console.WriteLine(inputs[j].error);
                    if (Math.Abs(inputs[j].error) > 0.01)
                    {
                        done = false;
                    }
                }

                Console.WriteLine(meanSquaredError(popSize));
                if (done)
                {
                    break;
                }
            }
        }
        //----------CALCULATE OUTPUTS----------//
        private void setNodeOutputs(int input)
        {
            foreach (Node n in nodes)
            {
                double sum = 0;
                for (int i = 0; i < INPUT_NO; i++)
                {
                    sum += n.weights[i] * inputs[input].input[i];
                }
                n.result = sum;
                n.output = activationFunction(sum);
            }
        }

        private void setOutput(int input)
        {
            double sum = 0;
            for(int i = 0; i< HIDDEN_NODES_NO; i++)
            {
                sum += inputs[input].getWeight(i) * nodes[i].output;
            }
            inputs[input].output = activationFunction(sum);
            inputs[input].result = sum;
        }

        //-----------ERROR--------------//

        private void setOutputError(int input)
        {
            inputs[input].error = (inputs[input].expectedOutput - inputs[input].output) * derivFunction(inputs[input].result);
        }

        private void setNodeErrors(int input)
        {
            for(int i = 0; i < HIDDEN_NODES_NO; i++)
            {
                nodes[i].error = (inputs[input].error * inputs[input].getWeight(i)) * derivFunction(nodes[i].result);
            }
        }
        //----------WEIGHT CHANGES-----///

        private void changeInputWeights(int input)
        {
            for (int i = 0; i < HIDDEN_NODES_NO; i++)
            {
                for (int j = 0; j < INPUT_NO; j++)
                {
                    nodes[i].weightChanges[j] = LEARNING_CONSTANT * nodes[i].error * inputs[input].input[j];
                    nodes[i].weights[j] += nodes[i].weightChanges[j];
                }
            }
        }

        private void changeOutputWeights(int input)
        {
            for (int i = 0; i < HIDDEN_NODES_NO; i++)
            {
                Input temp = inputs[input];
                temp.setWeightChange(i, LEARNING_CONSTANT * temp.error * nodes[i].result);
                temp.setWeight(i, temp.getWeight(i) + temp.getWeightChange(i));
            }
        }

        //------------WEIGHTS----------//

       private void initWeightIntervals(int wLower, int wUpper)
        {
            if (wLower < wUpper)
            {
                if (wLower > MIN_WEIGHT_INTERVAL)
                {
                    MIN_WEIGHT_INTERVAL = wLower;
                }
                if (wUpper < MAX_WEIGHT_INTERVAL)
                {
                    MAX_WEIGHT_INTERVAL = wUpper;
                }
            }
        }

       private double[] randomWeights(int size)
        {
            double [] w = new double[size];
            for (int i = 0; i < size; i++)
            {
                w[i] = randomWeight();
            }
            return w;
        }

        private double randomWeight()
        {
            return rand.NextDouble() + rand.Next(MIN_WEIGHT_INTERVAL, MAX_WEIGHT_INTERVAL - 1);
        }

        //-----ACTIVATION FUNCTION----//
        private double activationFunction(double x)
        {
            switch (activation)
            {
                case Activation.nullA:
                    return nullActivation(x);
                case Activation.sigmoid:
                    return sigmoidActivation(x);
                case Activation.tangent:
                    return tangentActivation(x);
                case Activation.cos:
                    return cosineActivation(x);
                case Activation.gaussian:
                    return gaussianActivation(x);
                default:
                    return 0;
            }

        }

        private double derivFunction(double x)
        {
            switch (activation)
            {
                case Activation.nullA:
                    return nullDeriv(x);
                case Activation.sigmoid:
                    return sigmoidDeriv(x);
                case Activation.tangent:
                    return tangentDeriv(x);
                case Activation.cos:
                    return cosineDeriv(x);
                case Activation.gaussian:
                    return gaussianDeriv(x);
                default:
                    return 0;
            }

        }

        private double nullActivation(double x)
        {
            return 0;
        }

        private double nullDeriv(double x)
        {
            return 0;
        }

        private double sigmoidActivation(double x)
        {
            return (1 / (1 + Math.Exp(-x)));
        }

        private double sigmoidDeriv(double x)
        {
            return sigmoidActivation(x) * (1 - sigmoidActivation(x));
        }

        private double tangentActivation(double x)
        {
            return Math.Tanh(x);
        }

        private double tangentDeriv(double x)
        {
            return 1 - (Math.Tanh(x) * Math.Tanh(x));
        }

        private double cosineActivation(double x)
        {
            return Math.Cos(x);
        }

        private double cosineDeriv(double x)
        {
            return -Math.Sin(x);
        }

        private double gaussianActivation(double x)
        {
            return Math.Exp(-(x * x / 2));
        }

        private double gaussianDeriv(double x)
        {
            return Math.Exp(-(x * x / 2));
        }

        private double meanSquaredError(int popSize)
        {
            double sum = 0;
            for (int j = 0; (j < inputs.Count && j < popSize); j++)
            {
                sum += Math.Pow(activationFunction(inputs[j].expectedOutput) - inputs[j].output, 2);
            }
            if (inputs.Count >= popSize)
            {
                return sum / inputs.Count;
            }
            else return sum / popSize;
        }
    }
}
