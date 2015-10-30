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
        public double weight { get; set; }
        public double expectedOutput { get; set; }

        public Input(double input, double weight, double expectedOutput)
        {
            this.input = new double[1];
            this.input[0] = input;
            this.weight = weight;
            this.expectedOutput = expectedOutput;
        }
        public Input(double input0, double input1, double weight, double expectedOutput)
        {
            this.input = new double[2];
            this.input[0] = input0;
            this.input[0] = input1;
            this.weight = weight;
            this.expectedOutput = expectedOutput;
        }
    }
}
