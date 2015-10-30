using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.IO;

namespace BIC_CW2
{
    public class MLP
    {
        List<Input> inputs;
        private static int MIN_WEIGHT_INTERVAL = -5;
        private static int MAX_WEIGHT_INTERVAL = 5;
        //for only one input for now
        public void initInput(int inputNo, String file, int wLower, int wUpper)
        {
            inputs = new List<Input>();
            if (wLower < MIN_WEIGHT_INTERVAL)
            {
                wLower = MIN_WEIGHT_INTERVAL;
            }
            if (wUpper > MAX_WEIGHT_INTERVAL)
            {
                wUpper = MAX_WEIGHT_INTERVAL;
            }
            Random rand = new Random();
            using (FileStream reader = File.OpenRead(file))
            using (TextFieldParser parser = new TextFieldParser(reader))
            {
                parser.TrimWhiteSpace = false; // if you want
                parser.Delimiters = new[] {"         ","\t", "    ", "   ", " " };
                parser.HasFieldsEnclosedInQuotes = true;
                while (!parser.EndOfData)
                {
                    String[] line = parser.ReadFields();
                    double weight = rand.NextDouble() + rand.Next(wLower, wUpper - 1);
                    if (line[0] == "")
                    {
                        for(int i = 0; i < line.Length - 1; i ++)
                        {
                            line[i] = line[i + 1];
                        }
                    }
                    if (inputNo == 1)
                    {
                        inputs.Add(new Input(Convert.ToDouble(line[0]), weight, Convert.ToDouble(line[1])));
                    }
                    else
                    {
                        inputs.Add(new Input(Convert.ToDouble(line[0]), Convert.ToDouble(line[1]), weight, Convert.ToDouble(line[2])));
                    }
                }
                Console.WriteLine("Got Inputs");
            }
        }

        public MLP(String file)
        {
            initInput(1, "..\\..\\"+file+".txt", -5, 5);
        }
        private float deltaWeight(float learningRate, float predictedO, float desiredO, float input)
        {
            return learningRate * (predictedO - desiredO) * input;
        }
    }
}
