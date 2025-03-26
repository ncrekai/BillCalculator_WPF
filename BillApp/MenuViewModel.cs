using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BillApp
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<MenuItem> _beverages;
        private ObservableCollection<MenuItem> _appetizers;
        private ObservableCollection<MenuItem> _mains;
        private ObservableCollection<MenuItem> _desserts;

        private double _subtotal;
        private double _tax;
        private double _grandtotal;

        private ObservableCollection<MenuItem> _selected = new ObservableCollection<MenuItem>();

        public MenuViewModel() 
        { 
            _beverages = new ObservableCollection<MenuItem>(MenuService.GetAll("beverage"));
            _appetizers = new ObservableCollection<MenuItem>(MenuService.GetAll("appetizer"));
            _mains = new ObservableCollection<MenuItem>(MenuService.GetAll("main"));
            _desserts = new ObservableCollection<MenuItem>(MenuService.GetAll("dessert"));

            _selected.CollectionChanged += selected_CollectionChanged;
            PropertyChanged += UpdateTotal;
        }

        public ObservableCollection<MenuItem> Beverages { get => _beverages; set => _beverages = value; }
        public ObservableCollection<MenuItem> Appetizers { get => _appetizers; set => _appetizers = value; }
        public ObservableCollection<MenuItem> Mains { get => _mains; set => _mains = value; }
        public ObservableCollection<MenuItem> Desserts { get => _desserts; set => _desserts = value; }

        public ObservableCollection<MenuItem> Selected { get => _selected; set => _selected = value; }             

        public double SubTotal 
        { 
            get => _subtotal; 
            set 
            { 
                _subtotal = value;
                OnPropertyChanged("subtotal");
            } 
        }
        public double Tax
        {
            get => _tax;
            set
            {
                _tax = value;
                OnPropertyChanged("tax");
            }
        }
        public double GrandTotal
        {
            get => _grandtotal;
            set
            {
                _grandtotal = value;
                OnPropertyChanged("grandtotal");
            }
        }

        public void HandleSelectedItem(MenuItem selectedItem)
        {
            if (selectedItem != null)
            {
                var existingItem = Selected.FirstOrDefault(item => item.Name == selectedItem.Name);

                if (existingItem != null)
                {
                    selectedItem.Quantity++;
                    int index = Selected.IndexOf(existingItem);
                    Selected.Remove(existingItem);
                    Selected.Insert(index, selectedItem);
                }
                else
                {
                    selectedItem.Quantity = 1;
                    Selected.Add(selectedItem);
                }
            }
        }

        public double CalculateSubTotal() 
        {
            double value = 0;
            foreach (var item in Selected) 
            {
                value += item.Quantity * item.Price;
            }
            return value;
        }        

        public void selected_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) { SubTotal = CalculateSubTotal(); }

        private void UpdateTotal(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "subtotal") { Tax = SubTotal * 0.13; }
            if (e.PropertyName == "tax") { GrandTotal = SubTotal + Tax; }
        }

        protected void OnPropertyChanged(string propertyName) { PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); }
    }
}
