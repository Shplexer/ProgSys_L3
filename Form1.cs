using ScottPlot.AxisLimitCalculators;
using System.Globalization;

namespace WinFormsApp1 {
    public partial class Form1 : Form {
        readonly ScottPlot.WinForms.FormsPlot fp;
        public Form1() {
            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
            fp = new() { Dock = DockStyle.Fill };

        }
        private static int CountDigitsAfterDecimalPoint(double number) {
            string numberString = number.ToString("0.#############################");

            // Check if there is a decimal point in the string
            int decimalPointIndex = numberString.IndexOf('.');
            int digitsAfterDecimal = 0;

            if (decimalPointIndex != -1) {
                // Count the digits after the decimal point
                digitsAfterDecimal = numberString.Length - decimalPointIndex - 1;
            }

            return digitsAfterDecimal;
        }

        private void button1_Click(object sender, EventArgs e) {

            // Add the FormsPlot
            //Controls.Add(fp);
            //textBox2.Text = textBox1.Text; 
            panel1.Controls.Remove(fp);
            var Ctg = new Func<double, double>((x) => 1 / Math.Tan(x));
            List<double> X = new();
            List<double> Y = new();
            double R = double.Parse(textBox1.Text);
            double step = double.Parse(textBox4.Text);
            double y1 = double.Parse(textBox2.Text);
            double y2 = double.Parse(textBox3.Text);
            //int R = 2;

            ScottPlot.Plot myPlot = fp.Plot;
            myPlot.Clear();
            panel1.Controls.Add(fp);


            for (double y = y1; y <= y2; y += step) {
                //X.Add(i);
                //Y.Add(i * i);
                //y = Math.Round(y, 3);

                double x = y * Ctg((Math.PI * y) / (2 * R));
                //x = Math.Round(x, 2);
                if (X.Count > 0) {
                    if ((y > 0 && X.Last() < x) || (y < 0 && X.Last() > x)) {
                        var scatter = myPlot.Add.Scatter(X.ToArray(), Y.ToArray());
                        scatter.MarkerSize = 0;
                        X.Clear();
                        Y.Clear();
                        myPlot = fp.Plot;
                        //myPlot.Add.Text(x + " " + y, x, y);
                    }
                }
                if (Math.Abs(Math.Tan((Math.PI * y) / (2 * R))) > 1e-10 && Math.Abs(Math.Tan((Math.PI * y) / (2 * R))) < 1e10) {
                    //myPlot.Add.Text(x + " " + $"{Math.Abs(Math.Tan((Math.PI * y) / (2 * R)))} " + y, x, y);
                    Y.Add(y);
                    X.Add(x);
                    int digitsAfterDecimal = CountDigitsAfterDecimalPoint(step);
                    dataGridView1.Rows.Add(x.ToString($"F{digitsAfterDecimal}"), y.ToString($"F{digitsAfterDecimal}"));
                }
                //myPlot.Add.Marker(x: y, y: x);

            }
            if (X.Count > 0) {
                var scatter = myPlot.Add.Scatter(X.ToArray(), Y.ToArray());
                scatter.MarkerSize = 0;
            }

            //var scatter2 = myPlot.Add.Scatter(X.ToArray(), Y.ToArray());
            //scatter2.MarkerSize = 0;
        }
    }
}
