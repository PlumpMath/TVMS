using System;
using System.Security.Policy;
using System.Windows.Forms;
using System.Xml.Serialization;
using TVMS.Computation;

namespace TVMS
{
    public partial class Form1 : Form
    {
        private double[] alphas = {0.05, 0.01, 0.001};
        /*
        private double[] testX = { 1.9, 5.5, 17.2, 7.6, 17.3, 10.7, 11.6, 20.5, 5.1, 17.5, 16.6, 18.3, 11, 13, 0.3, 19.2, 21.8, 8.3, 4.2, 21.2 };
        private double[] testY = { -9, -18.5, -43.8, -21.7, -41.4, -28.2, -27.3, -47.4, -13.3, -37.4, -35.8, -42.1, -25.4, -37.2, 1.9, -45.3, -48.3, -20.6, -12.9, -51.1 };
        
        private double testK = -2.175305737;
        private double testB = -3.179196637;
        */
        public Form1()
        {
            InitializeComponent();
            foreach (double alpha in alphas)
            {
                input_alpha.Items.Add(alpha);
            }
        }

        private double[] X;

        private double[] Y;

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //Text text = new Text();
            /*
            Calculation calculation = new Calculation(X, Y);
            MessageBox.Show($"{calculation.ExpectationX:#.##}");
            MessageBox.Show($"{calculation.ExpectationY:#.##}");
            MessageBox.Show($"{calculation.VarianceX:#.##}");
            MessageBox.Show($"{calculation.VarianceY:#.##}");
            MessageBox.Show($"{calculation.SigmaX:#.##}");
            MessageBox.Show($"{calculation.SigmaY:#.##}");
            MessageBox.Show($"{calculation.TDelta:#.##}");
            MessageBox.Show($"{calculation.YieldPoint:#.##}");
            MessageBox.Show($"{calculation.pValue}");
            */
        }

        private void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(13))
                Action.Click += Action_Click;
            if (e.KeyChar == Convert.ToChar(46))
                e.KeyChar = Convert.ToChar(44);
            if (!Char.IsDigit(e.KeyChar)
                && e.KeyChar != Convert.ToChar(8)
                && e.KeyChar != Convert.ToChar(32)
                && e.KeyChar != Convert.ToChar(44)
                && e.KeyChar != Convert.ToChar(45))
                e.Handled = true;
        }

        private void Action_Click(object sender, EventArgs e)
        {
            string name;
            string teacher;
            string group;
            string X;
            string Y;
            int n;
            double alpha;
            try
            {
                name = input_name.Text.Trim();
                teacher = input_teacher.Text.Trim();
                group = input_group.Text.Trim();
                n = int.Parse(input_n.Text.Trim());
                alpha = double.Parse(input_alpha.Text.Trim());
                X = input_X.Text.Trim();
                Y = input_Y.Text.Trim();
                var xArray = X.Split(' ');
                var yArray = Y.Split(' ');
                if (xArray.Length != yArray.Length)
                    throw new ArgumentException("Количество элементов в двух выборках не совпадает или поставлен лишний пробел");

                this.X = new double[xArray.Length];
                this.Y = new double[yArray.Length];

                for (int i = 0; i < xArray.Length; i++)
                {
                    double.TryParse(xArray[i], out this.X[i]);
                    double.TryParse(yArray[i], out this.Y[i]);
                }
                string year = DateTime.Now.Year.ToString();
                
                var calc = new Calculation(this.X, this.Y, alpha);
                var plotGraph = new PlotGraph(this.X, this.Y, calc.Koefficients[0], calc.Koefficients[1]);
                var text = new Text(group, name, teacher, year, n, alpha, this.X, this.Y);
                MessageBox.Show("Уважаемый, " + name + ", Ваша курсовая готова!");
            }
            catch (Exception ex)
            {
                
                throw new ArgumentException(ex.Message);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //PlotGraph graph = new PlotGraph(testX, testY, testK, testB);
            //Text text = new Text("2254", "Кузнецов В.В.", "Доц. Копылова Т.В.", "2016", 20, 0.01, testX, testY);
        }

        private void input_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(44))
                e.KeyChar = Convert.ToChar(46);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var info = new Info();
            info.Show();
        }
    }
}
