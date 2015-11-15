using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Diagnostics;

namespace GraphDisplay
{
    public partial class PerfGraph : Form
    {

        public GraphPane ratesGraph_pane;
        public GraphPane meansGraph_pane;
        RollingPointPairList desiredOutput_points = new RollingPointPairList(22);
        RollingPointPairList mlpOutput_points = new RollingPointPairList(22);
        RollingPointPairList msqError_points = new RollingPointPairList(22);

        LineItem desiredOutput_line;
        LineItem mlpOutput_line;

        LineItem msqError_line;
        public double deltaTime = 0;


        String chosenRadio;
        bool checked_EvolveWeights = false;
        bool checked_EvolveFunction = false;

        int pop_size;
        int noOfIterations;
        double mutRate;
        double crossoverRate;
        int min;
        int max;


        public PerfGraph()
        {
            InitializeComponent();
        }


        private void PerfGraph_Load(object sender, EventArgs e)
        {
            ratesGraph_pane = ratesGraph.GraphPane;
            meansGraph_pane = meansGraph.GraphPane;

            ratesGraph.GraphPane.Chart.Fill.Brush = new System.Drawing.SolidBrush(Color.GhostWhite);
            ratesGraph.GraphPane.Fill.Color = Color.FloralWhite;

            meansGraph.GraphPane.Chart.Fill.Brush = new System.Drawing.SolidBrush(Color.AntiqueWhite);
            meansGraph.GraphPane.Fill.Color = Color.FloralWhite;

            // Set the Titles
            ratesGraph_pane.Title.Text = "Desired vs MLP's output";
            ratesGraph_pane.XAxis.Title.Text = "x";
            ratesGraph_pane.YAxis.Title.Text = "y";

            meansGraph_pane.Title.Text = "Means Squared Error";
            meansGraph_pane.XAxis.Title.Text = "x";
            meansGraph_pane.YAxis.Title.Text = "y";

            desiredOutput_line = ratesGraph_pane.AddCurve("Desired Output",
                  desiredOutput_points, Color.Red, SymbolType.Circle);
            mlpOutput_line = ratesGraph_pane.AddCurve("MLP output",
                  mlpOutput_points, Color.BlueViolet, SymbolType.XCross);

            msqError_line = meansGraph_pane.AddCurve("Means Squared Error",
                  msqError_points, Color.Black, SymbolType.Circle);


            ratesGraph.AxisChange();
            meansGraph.AxisChange();
        }

        //initial graphs set up 
        private void plotGraphs()
        {
           



            
        }

       /* private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            deltaTime += UpdateTimer.Interval / 1000;
            Random rnd = new Random();
            Random rnd2 = new Random();

            desiredOutput_points.Add(deltaTime, rnd.Next(1, 10));
            mlpOutput_points.Add(deltaTime, rnd.Next(1, 20));

            msqError_points.Add(deltaTime, rnd2.Next(0, 5));

            ratesGraph.AxisChange();
            ratesGraph.Invalidate();

            meansGraph.AxisChange();
            meansGraph.Invalidate();

        }*/

        //update graph with new values
        public void updateRates(double desired_Output, double mlp_Output)
        {
            desiredOutput_points.Add(1, desired_Output);
            mlpOutput_points.Add(1, mlp_Output);

            ratesGraph.AxisChange();
            ratesGraph.Invalidate();

        }

        //change MSE
        public void updateMSE(double mse)
        {
            msqError_points.Add(1, mse);

            meansGraph.AxisChange();
            meansGraph.Invalidate();

        }



        //radio buttons "selected" event handlers------------------------------------------
        private void fn_linearradio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
            {
                chosenRadio = "1in_linear";
            }
        }

        private void fn_cubicradio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
            {
                chosenRadio = "1in_cubic";
            }
        }

        private void fn_sineradio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
            {
                chosenRadio = "1in_sine";
            }
        }

        private void fn_tanhradio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
            {
                chosenRadio = "1in_tanh";
            }
        }

        private void fn_xorradio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
            {
                chosenRadio = "2in_xor";
            }
        }

        private void fn_complexradio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            Debug.WriteLine(rdb.Name);
            if (rdb.Checked)
            {
                chosenRadio = "2in_complex";
                
            }
        }

        private void fetchTextBoxesData()
        {
            pop_size = Int32.Parse((this.Controls.Find("input_popsize", true).FirstOrDefault() as TextBox).Text);
            noOfIterations = Int32.Parse((this.Controls.Find("input_numofiterations", true).FirstOrDefault() as TextBox).Text);
            double mutRate = Double.Parse((this.Controls.Find("input_mutationrate", true).FirstOrDefault() as TextBox).Text);
            double crossoverRate = Double.Parse((this.Controls.Find("input_crossoverRate", true).FirstOrDefault() as TextBox).Text);
            int min = Int32.Parse((this.Controls.Find("input_weight_min", true).FirstOrDefault() as TextBox).Text);
            int max;
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {

        }

        //---------------------------------------------------------------------------------

    }
}