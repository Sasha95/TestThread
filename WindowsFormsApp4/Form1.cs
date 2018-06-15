using System;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        DataProducer dp;
        public Form1()
        {
            InitializeComponent();

            dp = new DataProducer();
            dp.StartDataProducing();
        }
        private void addPoint(double x, double y)
        {
            try
            {
                Invoke(new MethodInvoker(() =>
                {
                    chart1.Series[0].Points.AddXY(x, y);
                }));
            }
            catch (ObjectDisposedException)
            {
                dp.NewDataPoint -= addPoint;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dp.NewDataPoint += addPoint;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dp.NewDataPoint -= addPoint;
        }
    }
}
