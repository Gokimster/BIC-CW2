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

namespace GraphDisplay
{
    public partial class PerfGraph : Form
    {

        public GraphPane graph;
        RollingPointPairList plot1 = new RollingPointPairList(40);
        public double deltaTime = 0;
        LineItem teamACurve; 

        public PerfGraph()
        {
            InitializeComponent();
        }

        private void PerfGraph_Load(object sender, EventArgs e)
        {
            graph = zedGraphControl1.GraphPane;
            this.WindowState = FormWindowState.Maximized;

            zedGraphControl1.GraphPane.Chart.Fill.Brush = new System.Drawing.SolidBrush(Color.DarkGray);
            zedGraphControl1.GraphPane.Fill.Color = Color.DarkGray;

            plotGraph();
            SetSize();
        }
      
        private void plotGraph()
        {
            

            // Set the Titles
            graph.Title.Text = "Value1 vs Value2";
            graph.XAxis.Title.Text = "x";
            graph.YAxis.Title.Text = "y";

            teamACurve = graph.AddCurve("plot1",
                  plot1, Color.Red, SymbolType.Diamond);


            zedGraphControl1.AxisChange();
        }

        private void SetSize()
        {
            zedGraphControl1.Location = new Point(0, 0);
            zedGraphControl1.IsShowPointValues = true;
            zedGraphControl1.Size = new Size(this.ClientRectangle.Width, this.ClientRectangle.Height);
        }

        private void PerfGraph_Resize(object sender, EventArgs e)
        {
            SetSize();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            deltaTime += UpdateTimer.Interval / 1000;
            Random rnd = new Random();

            plot1.Add(deltaTime, rnd.Next(1, 10));
            //teamACurve.AddPoint(9 + deltaTime, rnd.Next(1, 10));
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }
    }
}
