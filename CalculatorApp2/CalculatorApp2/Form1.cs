using System.Data;

namespace CalculatorApp2
{
    public partial class Form1 : Form
    {
        private string currentcalculation = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtOutput.Text = "0";
        }

        private void button_click(object sender, EventArgs e)
        {
            currentcalculation += (sender as Button).Text;
            txtOutput.Text = currentcalculation;
        }

        private void button_equals_click(object sender, EventArgs e)
        {
            string formattedcalculation = currentcalculation.ToString();
            try
            {
                txtOutput.Text = new DataTable().Compute(formattedcalculation, null).ToString();
                currentcalculation = txtOutput.Text;
            }
            catch (Exception ex)
            {
                txtOutput.Text = "ERROR";
                currentcalculation = "";
            }

        }
        private void button_clear_click(object sender, EventArgs e)
        {
            txtOutput.Text = "0";
            currentcalculation = "";
        }

        private void button_delete_click(object sender, EventArgs e)
        {
            if (currentcalculation.Length > 0)
            {
                currentcalculation = currentcalculation.Substring(0, currentcalculation.Length - 1);

                if (currentcalculation.Length > 0)
                {
                    txtOutput.Text = currentcalculation;
                }
                else
                {
                    txtOutput.Text = "0";
                }
            }
        }

        
    }
}
