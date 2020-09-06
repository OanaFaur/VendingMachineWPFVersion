using BusinessLogic.Services;
using Caliburn.Micro;
using DataAccess.Models;

using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace VendingMachineTutorial.ViewModels
{
    public class MachineViewModel : Screen
    {

        IProductService productServices = new ProductService();
        IProductRepository repo = new ProductRepository();
       
        public PaymentViewModel Pays { get; private set; }

        public MachineViewModel()
        {
            Pays = new PaymentViewModel();

            var items = productServices.GetProductList();
            Itemuri = new BindingList<Product>(items);

        }

        private BindingList<Product> _itemuri;

        public BindingList<Product> Itemuri
        {
            get { return _itemuri; }
            set
            {
                _itemuri = value;
                NotifyOfPropertyChange(() => Itemuri);
            }
        }

        private void LoadProducts()
        {
            var items = productServices.GetProductList();
            Itemuri = new BindingList<Product>(items);
        }

        private Product _selectedProducts;

        public Product SelectedProducts
        {
            get { return _selectedProducts; }

            set
            {
                _selectedProducts = value;
                NotifyOfPropertyChange(() => SelectedProducts);
                NotifyOfPropertyChange(() => IsItemInStocks);
            }
        }

        private Product _itemToDecrement;

        public Product itemToDecrement
        {
            get { return _itemToDecrement; }

            set
            {
                _itemToDecrement = value;
                NotifyOfPropertyChange(() => itemToDecrement);
             //   NotifyOfPropertyChange(() => IsItemInStocks);
            }

        }
        

        private int _itemQuantit=0;

        public int ItemQuantity
        {
            get { return _itemQuantit; }
            set
            {
                _itemQuantit = value;
                NotifyOfPropertyChange(() => ItemQuantity);
            }
        }


        private BindingList<ShoppingBasketItem> _baskets = new BindingList<ShoppingBasketItem>();

        public BindingList<ShoppingBasketItem> Baskets
        {
            get { return _baskets; }
            set
            {
                _baskets = value;
                NotifyOfPropertyChange(() => Baskets);
            }
        }

        public void AddToBasket()
        {
            
            ShoppingBasketItem existingItem = Baskets.FirstOrDefault(x => x.Product == SelectedProducts);

            if (existingItem != null)
            {
                existingItem.Quantity++;
                
            }
            else
            {
                ShoppingBasketItem item = new ShoppingBasketItem
                {
                    Product = SelectedProducts,
                    Quantity = 1
                    
                };
                
                Baskets.Add(item);

            }

            SelectedProducts.ItemsLeft--;

            repo.UpdateQuantity(SelectedProducts);
            NotifyOfPropertyChange(() => CalculateChange);
            NotifyOfPropertyChange(() => Totals);
            NotifyOfPropertyChange(() => Baskets);
            
            
        }

        public void RemoveFromBasket()
        {
            ShoppingBasketItem existingItem = Baskets.FirstOrDefault(x => x.Product == SelectedProducts);


            if (existingItem != null)
            {
                if (existingItem.Quantity == 1)
                {
                    SelectedProducts.ItemsLeft++;
                    repo.UpdateQuantity(SelectedProducts);
                    Baskets.Remove(existingItem);

                }
                else if (existingItem.Quantity > 1)
                {
                    existingItem.Quantity--;

                    SelectedProducts.ItemsLeft++;
                    repo.UpdateQuantity(SelectedProducts);

                }

            }
            

            NotifyOfPropertyChange(() => Totals);
            NotifyOfPropertyChange(() => Baskets);
            NotifyOfPropertyChange(() => CalculateChange);
        }

        

        public double Totals
        {
            get
            {
                double total = 0;

                foreach (var items in Baskets)
                {
                    total += (items.Product.Price * items.Quantity);
                }

                return total;
            }
        }
        
        public double CalculateChange
        {
            get
            {
                return Pays.Inserted - Totals;
            }
            set
            {
                NotifyOfPropertyChange(() => CalculateChange);
                NotifyOfPropertyChange(() => Totals);
                NotifyOfPropertyChange(() => Baskets);
            }
        }


        public bool IsItemInStocks
        {
            get
            {

                bool output = false;

                if (SelectedProducts?.ItemsLeft >= 0)
                {

                    output = true;
                }

                return output;
            }
        }


        public void InsertChange(double value)
        {
            Pays.Insert(value);
        }
    }
}
