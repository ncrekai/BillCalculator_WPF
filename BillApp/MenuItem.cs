using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace BillApp
{
    public class MenuItem
    {
        private string _name;
        private double _price;

        private int _quantity = 0;

        public string Name { get { return _name; } }
        public double Price {  get { return _price; } }
        public int Quantity { get => _quantity; set => _quantity = value; }

        public string Display {  get { return DisplayMenuItem(); } }

        public MenuItem(string name, double price)
        {
            _name = name;
            _price = price;
        }

        public void UpdateQuantity(bool increase)
        {
            if (increase) Quantity++;
            else Quantity--;
        }

        public string DisplayMenuItem()
        {
            StringBuilder sb = new();
            
            string _priceStr = String.Format("{0:C}", _price);

            sb.Append(_name.PadRight(18, ' '));
            sb.Append(_priceStr.PadLeft(6, ' '));

            return sb.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
