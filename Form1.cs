using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;

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
            try
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

                timer1.Interval = 1000;
                timer1.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Device dev = (Device)listBox1.SelectedItem;
                MessageBox.Show(dev.Info());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            List<Device> list = devices.ToList();
            list.Sort(delegate (Device x, Device y)
            {
                if (x.Name == null && y.Name == null) return 0;
                else if (x.Name == null) return -1;
                else if (y.Name == null) return 1;
                else return x.Name.CompareTo(y.Name);
            });
            for (int i = 0; i < list.Count; i++)
                devices[i] = list[i];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.DataSource = devices;
            listBox1.DisplayMember = "Name";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            List<Device> list = devices.ToList();
            list.Sort(delegate (Device x, Device y)
            {
                if (x.Cost == 0 && y.Cost == 0) return 0;
                else if (x.Cost == 0) return -1;
                else if (y.Cost == 0) return 1;
                else return x.Cost.CompareTo(y.Cost);
            });
            for (int i = 0; i < list.Count; i++)
                devices[i] = list[i];
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            List<Device> list = devices.ToList();
            list.Sort(delegate (Device x, Device y)
            {
                if (x.Weight == 0 && y.Weight == 0) return 0;
                else if (x.Weight == 0) return -1;
                else if (y.Weight == 0) return 1;
                else return x.Weight.CompareTo(y.Weight);
            });
            for (int i = 0; i < list.Count; i++)
                devices[i] = list[i];
        }
    }
}