using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class ShoppingBasketItem:INotifyPropertyChanged
    {
        public Product Product { get; set; }
        private int _quantityInCart;
        public int Quantity { get
            {
                return _quantityInCart;
            }
            set
            {
                _quantityInCart = value;
                CallPropertyChanged(nameof(Quantity));
                CallPropertyChanged(nameof(DisplayProductProp));
            }
        }
        public string DisplayProductProp
        {
            get
            {
                return $"{Product.Name} ({Quantity})";
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void CallPropertyChanged(string propertyChanged)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}
