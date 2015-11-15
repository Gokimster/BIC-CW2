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

        private int interval_rates = 0;
        private int interval_mse = 0;
        private EvolutionMgr evmgr;
        public GraphPane ratesGraph_pane;
        public GraphPane meansGraph_pane;
        RollingPointPairList desiredOutput_points = new RollingPointPairList(100);
        RollingPointPairList mlpOutput_points = new RollingPointPairList(100);
        RollingPointPairList msqError_points = new RollingPointPairList(100);

        LineItem desiredOutput_line;
        LineItem mlpOutput_line;

        LineItem msqError_line;
        public double deltaTime = 0;


        String chosenRadio="";
        bool checked_EvolveWeights = false;
        bool checked_EvolveFunction = false;

        int pop_size;
        int noOfIterations;
        double mutRate;
        double crossoverRate;
        int min;
        int max;
        BackgroundWorker worker;


        public PerfGraph()
        {

            InitializeComponent();
            worker = new BackgroundWorker();
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        }


        private void PerfGraph_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            ratesGraph_pane = ratesGraph.GraphPane;
            meansGraph_pane = meansGraph.GraphPane;

            ratesGraph.GraphPane.Chart.Fill.Brush = new System.Drawing.SolidBrush(Color.GhostWhite);
            ratesGraph.GraphPane.Fill.Color = Color.FloralWhite;

            meansGraph.GraphPane.Chart.Fill.Brush = new System.Drawing.SolidBrush(Color.AntiqueWhite);
            meansGraph.GraphPane.Fill.Color = Color.FloralWhite;

            // Set the Titles
            ratesGraph_pane.Title.Text = "Desired vs MLP's output";
            ratesGraph_pane.XAxis.Title.Text = "input";
            ratesGraph_pane.YAxis.Title.Text = "result";

            meansGraph_pane.Title.Text = "Mean Squared Error";
            meansGraph_pane.XAxis.Title.Text = "epoch";
            meansGraph_pane.YAxis.Title.Text = "value";

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
            desiredOutput_points.Add(interval_rates, desired_Output);
            mlpOutput_points.Add(interval_rates, mlp_Output);

            ratesGraph.AxisChange();
            ratesGraph.Invalidate();
            interval_rates += 1;

        }

        //change MSE
        public void updateMSE(double mse)
        {
            msqError_points.Add(interval_mse, mse);

            meansGraph.AxisChange();
            meansGraph.Invalidate();

            interval_mse += 1;

        }

        public void updateLabel_evolutionary(String input)
        {
            Invoke(new Action(() =>
            {
                evolution_Stage.Text = input;
            }));
        }

        public void updateLabel_individual(String input)
        {
            Invoke(new Action(() =>
            {
                individual_MLP_stage.Text = input;
            }));
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

        private void radfn_xorradio_CheckedChanged(object sender, EventArgs e)
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

        private void checked_weights_CheckedChanged(object sender, EventArgs e)
        {
            if (checked_EvolveWeights == false)
            { checked_EvolveWeights = true; }
            else checked_EvolveWeights = false;
        }

        private void checked_activationfn_CheckedChanged(object sender, EventArgs e)
        {
            if (checked_EvolveFunction == false)
            { checked_EvolveFunction = true; }
            else checked_EvolveFunction = false;
        }

        private void fetchTextBoxesData()
        {
            pop_size = Int32.Parse((this.Controls.Find("input_popsize", true).FirstOrDefault() as TextBox).Text);
            noOfIterations = Int32.Parse((this.Controls.Find("input_numofiterations", true).FirstOrDefault() as TextBox).Text);
            mutRate = Double.Parse((this.Controls.Find("input_mutationrate", true).FirstOrDefault() as TextBox).Text);
            crossoverRate = Double.Parse((this.Controls.Find("input_crossoverRate", true).FirstOrDefault() as TextBox).Text);
            min = Int32.Parse((this.Controls.Find("input_weight_min", true).FirstOrDefault() as TextBox).Text);
            max = Int32.Parse((this.Controls.Find("input_weight_min", true).FirstOrDefault() as TextBox).Text);
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            //TODO check if either is null
            fetchTextBoxesData();
            evmgr = new EvolutionMgr(this, chosenRadio, checked_EvolveWeights, checked_EvolveFunction, pop_size, noOfIterations, mutRate, crossoverRate, min, max);
            worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            evmgr.run();
        }

        //---------------------------------------------------------------------------------

    }
}