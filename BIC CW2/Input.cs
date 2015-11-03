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
        public double[] weights { get; set; }
        public double expectedOutput { get; set; }

        public Input(double input, double []weights, double expectedOutput)
        {
            this.input = new double[1];
            this.input[0] = input;
            this.weights = weights;
            this.expectedOutput = expectedOutput;
        }
        public Input(double input0, double input1, double[] weights, double expectedOutput)
        {
            this.input = new double[2];
            this.input[0] = input0;
            this.input[0] = input1;
            this.weights = weights;
            this.expectedOutput = expectedOutput;
        }
    }
}
