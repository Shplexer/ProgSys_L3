using ScottPlot;
using ScottPlot.AxisLimitCalculators;
using System.Globalization;

namespace WinFormsApp1 {
    public partial class Form1 : Form {
        readonly ScottPlot.WinForms.FormsPlot fp;
        public Form1() {

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
            InitializeComponent();
            fp = new() { Dock = DockStyle.Fill };
            fp.Plot.XLabel("X");
            fp.Plot.YLabel("Y");
            fp.Plot.Style.Background(figure: ScottPlot.Color.FromHex("#273043"), data: ScottPlot.Color.FromHex("#273043"));
            fp.Plot.Style.ColorAxes(ScottPlot.Color.FromHex("#a0acb5"));
            panel1.Controls.Add(fp);

        }
        private static int CountDigitsAfterDecimalPoint(double number) {
            string numberString = number.ToString("0.#############################");

            int decimalPointIndex = numberString.IndexOf('.');

            int digitsAfterDecimal = 0;

            if (decimalPointIndex != -1) {
                digitsAfterDecimal = numberString.Length - decimalPointIndex - 1;
            }

            return digitsAfterDecimal;
        }
        private void TextBoxGeneral_KeyPress(object sender, KeyPressEventArgs e) {
            if (!double.TryParse(y1Box.Text + e.KeyChar.ToString(), out double a) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != ',' && e.KeyChar != '-') {
                e.Handled = true;
            }
        }
        private void TextBoxPos_KeyPress(object sender, KeyPressEventArgs e) {
            if (!double.TryParse(y1Box.Text + e.KeyChar.ToString(), out double a) && e.KeyChar != 8 && e.KeyChar != '.' && e.KeyChar != ',') {
                e.Handled = true;
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e) {
            List<TextBox> textBoxes = new() { radiusBox, y1Box, y2Box, stepBox };

            bool errFlag = false;
            foreach (TextBox textBox in textBoxes) {
                if (!IsValidNumber(textBox.Text)) {
                    errFlag = true;
                    MarkError(textBox);
                }
                else {
                    UnmarkError(textBox);
                }
            }
            if (!AreBordersCorrect(y1Box.Text, y2Box.Text)) {
                //errLabel.Text = $"{!areBordersCorrect(y1Box.Text, y2Box.Text)}";
                errFlag = true;
                MarkError(y1Box);
                MarkError(y2Box);
            }
            else {
                UnmarkError(y1Box);
                UnmarkError(y2Box);
            }
            if (!IsPositive(stepBox)) {
                errFlag = true;
                MarkError(stepBox);
            }
            else {
                UnmarkError(stepBox);
                buildBtn.Enabled = true;
            }
            if (!IsPositive(radiusBox)) {
                errFlag = true;
                MarkError(radiusBox);
            }
            else {
                UnmarkError(radiusBox);
                buildBtn.Enabled = true;
            }
            buildBtn.Enabled = !errFlag;

        }
        private static bool IsValidNumber(string input) {
            return !string.IsNullOrWhiteSpace(input) && double.TryParse(input, out _);
        }
        private static void MarkError(TextBox textBox) {
            textBox.ForeColor = System.Drawing.Color.Red;
        }
        private static void UnmarkError(TextBox textBox) {
            textBox.ForeColor = System.Drawing.Color.Black;
        }
        private static bool AreBordersCorrect(string y1S, string y2S) {
            if (string.IsNullOrEmpty(y1S) || string.IsNullOrEmpty(y2S)) return true;
            if (!double.TryParse(y1S.Replace(',', '.'), out double y1) || !double.TryParse(y2S.Replace(',', '.'), out double y2))
                return false;
            return y1 < y2;
        }
        private static bool IsPositive(TextBox textBox) {
            if (!double.TryParse(textBox.Text.Replace(',', '.'), out double number)) return false;
            return number > 0;
        }


        private void BuildGraph() {
            ScottPlot.Plot myPlot = fp.Plot;

            panel1.Controls.Remove(fp);
            myPlot.Clear();
            panel1.Controls.Add(fp);
            resultsTable.Rows.Clear();

            var Ctg = new Func<double, double>((x) => 1 / Math.Tan(x));
            List<double> XList = new();
            List<double> YList = new();
            double R = double.Parse(radiusBox.Text.Replace(',', '.'));
            double step = double.Parse(stepBox.Text.Replace(',', '.'));
            double y1 = double.Parse(y1Box.Text.Replace(',', '.'));
            double y2 = double.Parse(y2Box.Text.Replace(',', '.'));
            //int R = 2;
            myPlot.Axes.SetLimitsY(y1, y2);

            for (double y = y1; y <= y2; y += step) {

                double x = y * Ctg((Math.PI * y) / (2 * R));
                if (XList.Count > 0) {
                    if ((y > 0 && XList.Last() < x) || (y < 0 && XList.Last() > x)) {
                        var scatter = myPlot.Add.Scatter(XList.ToArray(), YList.ToArray());
                        scatter.MarkerSize = 0;
                        scatter.Color = ScottPlot.Color.FromHex("#F02D3A");
                        XList.Clear();
                        YList.Clear();
                        myPlot = fp.Plot;
                    }
                }
                if (Math.Abs(Math.Tan((Math.PI * y) / (2 * R))) > 1e-10 && Math.Abs(Math.Tan((Math.PI * y) / (2 * R))) < 1e10) {
                    YList.Add(y);
                    XList.Add(x);
                    int digitsAfterDecimal = CountDigitsAfterDecimalPoint(step);
                    resultsTable.Rows.Add(x.ToString($"F{digitsAfterDecimal}"), y.ToString($"F{digitsAfterDecimal}"));
                }

            }
            if (XList.Count > 0) {
                var scatter = myPlot.Add.Scatter(XList.ToArray(), YList.ToArray());
                scatter.MarkerSize = 0;
                scatter.Color = ScottPlot.Color.FromHex("#F02D3A");
            }
        }

        private void BuildBtn_Click(object sender, EventArgs e) {
            saveBtn.Enabled = true;
            BuildGraph();
        }
        private void LoadBtn_Click(object sender, EventArgs e) {
            openFileDialog1.Filter = "Text File|*.txt";
            openFileDialog1.Title = "Open Text File";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK) {
                string filePath = openFileDialog1.FileName;

                using StreamReader reader = new(filePath);
                radiusBox.Text = reader.ReadLine();
                stepBox.Text = reader.ReadLine();
                y1Box.Text = reader.ReadLine();
                y2Box.Text = reader.ReadLine();
                reader.Close();
                MessageBox.Show("Данные успешно загружены из файла: " + filePath);
                BuildGraph();
            }

        }
        private void SaveBtn_Click(object sender, EventArgs e) {

            saveFileDialog1.Filter = "Text File|*.txt";
            saveFileDialog1.Title = "Save to Text File";
            saveFileDialog1.CheckFileExists = false;
            saveFileDialog1.CheckPathExists = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                string filePath = saveFileDialog1.FileName;
                using StreamWriter writer = new(filePath);
                writer.WriteLine(radiusBox.Text);
                writer.WriteLine(stepBox.Text);
                writer.WriteLine(y1Box.Text);
                writer.WriteLine(y2Box.Text);
                writer.WriteLine("//");
                writer.WriteLine("Результаты:");
                foreach (DataGridViewRow row in resultsTable.Rows) {
                    foreach (DataGridViewCell cell in row.Cells) {
                        writer.Write($"{cell.Value} ");
                    }
                    writer.WriteLine();
                }

                writer.Close();
                MessageBox.Show("Данные из таблицы успешно сохранены в файл: " + filePath);
            }
        }
        private static void InfoBtn_Click(object sender, EventArgs e) {
            InfoForm info = new();
            info.ShowDialog();
        }
    }
}
