using System;
using System.Threading;
using System.Threading.Tasks;

namespace WindowsFormsApp4
{
    public class DataProducer
    {
        Random rnd; 

        public delegate void NewDataPointDelegate(double x, double y);
        public event NewDataPointDelegate NewDataPoint;
        public DataProducer()
        {
            rnd = new Random();
        }
        public void StartDataProducing()
        {
            Task.Run(new Action(GeneratePoints));
        }

        private void GeneratePoints()
        {
            while (true)
            {
                var phi = rnd.NextDouble() * 2 * Math.PI;
                var x = rnd.NextDouble() * 0.1 + Math.Sin(phi);
                var y = rnd.NextDouble() * 0.1 + Math.Cos(phi);

                Thread.Sleep(200);

                if (NewDataPoint != null)
                    NewDataPoint.Invoke(x, y);
            }
        }
    }
}
