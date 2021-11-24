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

            devices.Add(new Device(Name, Weight, Cost, Status));
            this.label7.Text = "Notes: " + Convert.ToString(devices.Count);

            foreach (var it in Controls)
                if (it is TextBox) ((TextBox)it).Text = string.Empty;

            listBox1.DataSource = devices;
            listBox1.DisplayMember = "Name";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Device dev = (Device)listBox1.SelectedItem;
            MessageBox.Show(dev.Info());
        }
    }
}