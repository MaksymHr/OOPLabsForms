using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

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

        private void button3_Click(object sender, EventArgs e)
        {
            string path = @$"C:\Users\maksi\source\repos\OOPLabsForms\{textBox4.Text}.txt";

            using (StreamWriter sw = new StreamWriter(path, false))
            {
                foreach (Device device in devices)
                    sw.WriteLine(device.Info());
                MessageBox.Show("Succesfull");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string path = @$"C:\Users\maksi\source\repos\OOPLabsForms\{textBox5.Text}.txt";

            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    List<string> lines = new List<string>();

                    while ((line = sr.ReadLine()) != null)
                        lines.Add(line);

                    //MessageBox.Show(String.Join("\n", lines));

                    devices.Clear();

                    for (int i = 0; i < lines.Count; i += 6)
                    {
                        devices.Add(new Device(
                            lines[i + 1].Substring(5),
                            lines[i + 2].Substring(7),
                            lines[i + 3].Substring(5),
                            lines[i + 4].Substring(7)
                        ));
                    }
                }

                this.label7.Text = "Notes: " + Convert.ToString(devices.Count);
                MessageBox.Show("Succesfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = @$"C:\Users\maksi\source\repos\OOPLabsForms\{textBox6.Text}.dat";

            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                    bf.Serialize(fs, devices);
                
                //using (BinaryWriter bw = new BinaryWriter(File.Open(path, FileMode.OpenOrCreate)))
                //    foreach (Device device in devices)
                //        bw.Write(device.Info());
                
                MessageBox.Show("Succesfull");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string path = @$"C:\Users\maksi\source\repos\OOPLabsForms\{textBox7.Text}.dat";

            try
            {
                BinaryFormatter bf = new BinaryFormatter();

                using (FileStream fs = new FileStream(path, FileMode.Open))
                    devices = (BindingList<Device>)bf.Deserialize(fs);

                this.label7.Text = "Notes: " + Convert.ToString(devices.Count);
                MessageBox.Show("Succesfull");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Error");
            }
        }
    }
}