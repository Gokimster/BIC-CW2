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
        public double expectedOutput { get; set; }
        public double output { get; set; }
        public double error { get; set; }
        public double result { get; set; }

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

        

    }
}
