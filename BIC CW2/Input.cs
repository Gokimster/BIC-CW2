using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIC_CW2
{
    public class Input
    {
        public double[] input { get; set; }
        public static double[] weights;
        public static double[] weightChanges;
        public double expectedOutput { get; set; }
        public double output { get; set; }
        public double error { get; set; }

        public Input()
        {

        }
        public Input(double input, double expectedOutput)
        {
            this.input = new double[1];
            this.input[0] = input;
            this.expectedOutput = expectedOutput;
        }
        public Input(double input0, double input1, double expectedOutput)
        {
            this.input = new double[2];
            this.input[0] = input0;
            this.input[0] = input1;
            this.expectedOutput = expectedOutput;
        }

        public void setWeights(double[] w)
        {
            weights = new double[w.Length];
            for (int i = 0; i < w.Length;i++)
            {
                weights[i] = w[i];
            }
        }

        public void setWeight(int i, double w)
        {
            weights[i] = w;
        }

        public double getWeight(int i)
        {
            return weights[i];
        }

        public void initWeightChanges(int noOfHidden)
        {
            weightChanges = new double[noOfHidden];
        }

        public void setWeightChange(double[] weightChange)
        {
            weightChanges = weightChange;
        }

        public void setWeightChange(int i, double weightChange)
        {
            weightChanges[i] = weightChange;
        }

        public double getWeightChange(int i)
        {
            return weightChanges[i];
        }

    }
}
