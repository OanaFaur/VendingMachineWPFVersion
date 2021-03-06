﻿using BusinessLogic.Services;
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

        private IProductService productServices = new ProductService();
        private IProductRepository repo = new ProductRepository();
        private IMoneyRepository moneyRepo = new MoneyRepository();
        private IMoneyService moneyService = new MoneyService();
        private BindingList<Product> _items;
        private BindingList<ShoppingBasketItem> _basket = new BindingList<ShoppingBasketItem>();
        private BindingList<Moneys> _machineMoney;

        public PaymentViewModel Pay { get; private set; }

        public MachineViewModel()
        {
            Pay = new PaymentViewModel();

            LoadProducts();
            LoadMoney();

        }


        public BindingList<Product> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                NotifyOfPropertyChange(() => Items);
            }
        }

        public BindingList<Moneys> MoneyList
        {
            get { return _machineMoney; }
            set

            {
                _machineMoney = value;
                NotifyOfPropertyChange(() => MoneyList);
            }

        }

        private void LoadProducts()
        {
            var items = productServices.GetProductList();
            Items = new BindingList<Product>(items);
        }

        private Product _selectedProducts;

        public Product SelectedProducts
        {
            get { return _selectedProducts; }

            set
            {
                _selectedProducts = value;
                NotifyOfPropertyChange(() => SelectedProducts);
                NotifyOfPropertyChange(() => IsItemInStock);
            }
        }

        private void LoadMoney()
        {
            var moneys = moneyService.GetMoneyList();
            MoneyList = new BindingList<Moneys>(moneys);
        }


        public BindingList<ShoppingBasketItem> Basket
        {
            get { return _basket; }
            set
            {
                _basket = value;
                NotifyOfPropertyChange(() => Basket);
            }
        }

        public void AddToBasket()
        {
            if (IsItemInStock)
            {
                ShoppingBasketItem existingItem = Basket.FirstOrDefault(x => x.Product == SelectedProducts);

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

                    Basket.Add(item);

                }

                SelectedProducts.ItemsLeft--;

                if (Pay.Inserted >= Total)
                {

                    repo.UpdateQuantity(SelectedProducts);
                }
            }
            else
            {
                MessageBox.Show("This item is out of stock");
            }

            NotifyOfPropertyChange(() => CalculateChange);
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => Basket);

        }

        public void RetrieveChange()
        {

            double count = 0;

            double change = CalculateChange;

            for (int i = MoneyList.Count - 1; i >= 0; i--)
            {
                
                count = (int)(change / MoneyList[i].MoneyType);

                if (count != 0)
                {
                    MoneyList[i].MoneyQuantity -= (int)count;
                    moneyRepo.UpdateMoneyQuantity(MoneyList[i]);

                    Console.WriteLine("Count of {0} cent(s) :{1}", MoneyList[i].MoneyType, count);

                    change %= (int)(MoneyList[i].MoneyType);
                }
            }

            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => Basket);
            NotifyOfPropertyChange(() => CalculateChange);
        }


        public void RemoveFromBasket()
        {
            ShoppingBasketItem existingItem = Basket.FirstOrDefault(x => x.Product == SelectedProducts);


            if (existingItem != null)
            {
                if (existingItem.Quantity == 1)
                {
                    SelectedProducts.ItemsLeft++;
                    repo.UpdateQuantity(SelectedProducts);
                    Basket.Remove(existingItem);

                }
                else if (existingItem.Quantity > 1)
                {
                    existingItem.Quantity--;

                    SelectedProducts.ItemsLeft++;
                    repo.UpdateQuantity(SelectedProducts);

                }
            }
            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => Basket);
            NotifyOfPropertyChange(() => CalculateChange);
        }



        public double Total
        {
            get
            {
                double total = 0;

                foreach (var items in Basket)
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
                return Pay.Inserted - Total;
            }
            set
            {
                NotifyOfPropertyChange(() => Basket);
                NotifyOfPropertyChange(() => Total);

                NotifyOfPropertyChange(() => CalculateChange);

            }
        }


        private bool IsItemInStock
        {
            get
            {

                bool output = false;

                if (SelectedProducts.ItemsLeft > 0)
                {

                    output = true;
                }

                return output;
            }
        }

        public void InsertChange(double value)
        {
            Pay.Insert(value);

            if (Pay.Inserted >= Total)
            {

                repo.UpdateQuantity(SelectedProducts);
            }

            NotifyOfPropertyChange(() => Total);
            NotifyOfPropertyChange(() => Basket);
            NotifyOfPropertyChange(() => CalculateChange);
        }
    }
}
