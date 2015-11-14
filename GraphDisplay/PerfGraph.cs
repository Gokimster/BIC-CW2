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

            plotGraphs();
        }

        //initial graphs set up 
        private void plotGraphs()
        {
            // Set the Titles
            ratesGraph_pane.Title.Text = "Desired vs MLP's output";
            ratesGraph_pane.XAxis.Title.Text = "x";
            ratesGraph_pane.YAxis.Title.Text = "y";

            ratesGraph_pane.Title.Text = "Means Squared Error";
            ratesGraph_pane.XAxis.Title.Text = "x";
            ratesGraph_pane.YAxis.Title.Text = "y";



            desiredOutput_line = ratesGraph_pane.AddCurve("Desired Output",
                  desiredOutput_points, Color.Red, SymbolType.Circle);
            mlpOutput_line = ratesGraph_pane.AddCurve("MLP output",
                  mlpOutput_points, Color.BlueViolet, SymbolType.XCross);

            msqError_line = meansGraph_pane.AddCurve("Means Squared Error",
                  msqError_points, Color.Black, SymbolType.Circle);


            ratesGraph.AxisChange();
            meansGraph.AxisChange();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
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

        }

        //update graph with new values
        public void updateGraph(double desired_Output, double mlp_Output, double mse)
        {
            desiredOutput_points.Add(deltaTime, desired_Output);
            mlpOutput_points.Add(deltaTime, mlp_Output);

            msqError_points.Add(deltaTime, mse);

            ratesGraph.AxisChange();
            ratesGraph.Invalidate();

            meansGraph.AxisChange();
            meansGraph.Invalidate();
        }



        //radio buttons "selected" event handlers------------------------------------------
        private void fn_linearradio_CheckedChanged(object sender, EventArgs e)
        {
            chosenRadio = "linear";
        }

        private void fn_cubicradio_CheckedChanged(object sender, EventArgs e)
        {
            chosenRadio = "cubic";
        }

        private void fn_sineradio_CheckedChanged(object sender, EventArgs e)
        {
            chosenRadio = "sine";
        }

        private void fn_tanhradio_CheckedChanged(object sender, EventArgs e)
        {
            chosenRadio = "tanh";
        }

        private void fn_xorradio_CheckedChanged(object sender, EventArgs e)
        {
            chosenRadio = "xor";
        }

        private void fn_complexradio_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdb = (RadioButton)sender;
            if (rdb.Checked)
            {
                chosenRadio = "complex";
                
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label_tickboxes_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //---------------------------------------------------------------------------------

    }
}