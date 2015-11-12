using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BIC_CW2
{
    public class Node
    {
        public double[] weights { get; set; }
        public double output { get; set; }
        public double error { get; set; }
        public double result { get; set; }
        public double[] weightChanges { get; set; }

        public Node(double[] weights, int noOfInputs)
        {
            this.weights = weights;
            weightChanges = new double[noOfInputs];
        }

    }
}
