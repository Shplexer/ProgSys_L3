namespace WinFormsApp1 {
    public partial class Form1 : Form {

        public Form1() {


            InitializeComponent();

            


        }

        private void button1_Click(object sender, EventArgs e) {
            // Add the FormsPlot
            var fp = new ScottPlot.WinForms.FormsPlot() { Dock = DockStyle.Fill };
            Controls.Add(fp);
            var Ctg = new Func<double, double>((x) => 1 / Math.Tan(x));
            List<double> X = new();
            List<double> Y = new();
            int R = 10;
            ScottPlot.Plot myPlot = fp.Plot;
            panel1.Controls.Add(fp);


            for (double y = -100; y <= 100; y += 0.1) {
                //X.Add(i);
                //Y.Add(i * i);
                y = Math.Round(y, 3);

                double x = y * Ctg((Math.PI * y) / (2 * R));
                //x = Math.Round(x, 2);

                if ((y > 0 && X.Last() < x && X.Count > 0) || (y < 0 && X.Count > 0 && X.Last() > x)) {
                    var scatter = myPlot.Add.Scatter(X.ToArray(), Y.ToArray());
                    scatter.MarkerSize = 0;
                    X.Clear();
                    Y.Clear();
                    myPlot = fp.Plot;
                }
                if (Math.Abs(Math.Tan((Math.PI * y) / (2 * R))) > 1e-15 && Math.Abs(Math.Tan((Math.PI * y) / (2 * R))) < 1e15) {
                    //myPlot.Add.Text(x + " " + $"{Math.Abs(Math.Tan((Math.PI * y) / (2 * R)))} " + y, x, y);
                    Y.Add(Math.Round(y, 5));
                    X.Add(Math.Round(x, 5));
                    //myPlot.Add.Text(x + " " + y, x, y);
                }
                //myPlot.Add.Marker(x: y, y: x);

            }
            //myPlot.Add.Scatter(X.ToArray(), Y.ToArray());

            //var scatter = myPlot.Add.Scatter(X.ToArray(), Y.ToArray());
            //scatter.MarkerSize = 0;
        }
    }
}
