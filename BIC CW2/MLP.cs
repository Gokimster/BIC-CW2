using Microsoft.VisualBasic.FileIO;
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
        private enum Activation {nullA, sigmoid, tangent, cos, gaussian};
        private Activation activation;
        private Random rand = new Random();

        public void initNodes()
        {
            nodes = new List<Node>();
            for(int i = 0; i < HIDDEN_NODES_NO; i++)
            {
                nodes.Add(new Node(randomWeight()));
            }
        }
        public void initInput(int inputNo, String file)
        {
            inputs = new List<Input>();
            using (FileStream reader = File.OpenRead(file))
            using (TextFieldParser parser = new TextFieldParser(reader))
            {
                parser.TrimWhiteSpace = false;
                //different delimiters to work with varying formatting of the files
                parser.Delimiters = new[] {"         ","\t", "    ", "   ", " " };
                parser.HasFieldsEnclosedInQuotes = true;
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
                    if (inputNo == 1)
                    {
                        inputs.Add(new Input(Convert.ToDouble(line[0]), randomWeights(), Convert.ToDouble(line[1])));
                    }
                    else
                    {
                        inputs.Add(new Input(Convert.ToDouble(line[0]), Convert.ToDouble(line[1]), randomWeights(), Convert.ToDouble(line[2])));
                    }
                }
                Console.WriteLine("Got Inputs");
            }
        }

        public MLP(String file, int minWeight, int maxWeight)
        {
            initWeightIntervals(minWeight, maxWeight);
            initInput(1, "..\\..\\"+file+".txt");
            initNodes();
        }

        private double deltaWeight(double learningRate, double predictedO, double desiredO, double input)
        {
            return learningRate * (predictedO - desiredO) * input;
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

       private double[] randomWeights()
        {
            double [] w = new double[HIDDEN_NODES_NO];
            for (int i = 0; i < HIDDEN_NODES_NO; i++)
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

        private double nullActivation(double x)
        {
            return 0;
        }

        private double sigmoidActivation(double x)
        {
            return (1 / (1 + Math.Exp(-x)));
        }

        private double tangentActivation(double x)
        {
            return Math.Tanh(x);
        }

        private double cosineActivation(double x)
        {
            return Math.Cos(x);
        }

        private double gaussianActivation(double x)
        {
            return Math.Exp(-(x * x / 2));
        }
    }
}
