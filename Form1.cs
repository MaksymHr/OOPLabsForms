namespace OOPLabsForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Name = textBox1.Text;
            double Weight = Convert.ToDouble(textBox2.Text);
            double Cost = Convert.ToDouble(textBox3.Text);
            string Status = comboBox1.Text;
        }
    }
}