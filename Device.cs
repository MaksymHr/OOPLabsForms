using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPLabsForms
{
    internal class Device
    {
        public string Name { get; set; }

        double weight;
        public double Weight
        {
            get => weight;
            set => weight = value < 0 ? 0 : value;
        }

        double cost;
        public double Cost
        {
            get => cost;
            set => cost = value < 0 ? 0 : value;
        }
        
        public string Status { get; set; }

        public Device(string _name, double _weight, double _cost, string _status)
        {
            Name = _name;
            Weight = _weight;
            Cost = _cost;
            Status = _status;
        }

        public Device(string _name, string _weight, string _cost, string _status)
        {
            Name = _name;
            Weight = Convert.ToDouble(_weight.Trim(new char[] {'g', ' '}));
            Cost = Convert.ToDouble(_cost.Trim(new char[] {'$', ' '}));
            Status = _status;
        }

        public void AddToList(List<Device> list)
        {
            return;
        }

        public string Info()
        {
            return
                $"Main info:\n" +
                $"Name: {this.Name}\n" +
                $"Weight: {this.Weight} g\n" +
                $"Cost: {this.Cost}$\n" +
                $"Status: {this.Status}\n";
        }
    }
}
