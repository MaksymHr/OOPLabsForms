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
            string Weight = textBox2.Text;
            int Cost = Convert.ToInt32(textBox3.Text);
            string Status = comboBox1.Text;
        }
    }
}