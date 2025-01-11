using System.Data;

namespace Calculator3
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
            TextBox.Text = "0";
        }

        private void button_click (object sender, EventArgs e)
        {
            currentcalculation += (sender as Button).Text;
            TextBox.Text = currentcalculation;
        }

        private void button_clear (object sender, EventArgs e)
        {
            TextBox.Text = "0";
            currentcalculation = "";
        }

        private void button_delete (object sender, EventArgs e)
        {
            if (currentcalculation.Length > 0)
            {
                currentcalculation = currentcalculation.Substring(0, currentcalculation.Length - 1);

                if (currentcalculation.Length > 0)
                {
                    TextBox.Text = currentcalculation;
                }
                else
                {
                    TextBox.Text = "0";
                }
            }
        }

        private void button_equals (object sender, EventArgs e)
        {
            string formattedcalculation = currentcalculation.ToString();

            try
            {
                TextBox.Text = new DataTable().Compute(formattedcalculation, null).ToString();
                currentcalculation = TextBox.Text;
            }
            catch (Exception ex)
            {
                TextBox.Text = "ERROR";
                currentcalculation = "";
            }
        }

    }
}
