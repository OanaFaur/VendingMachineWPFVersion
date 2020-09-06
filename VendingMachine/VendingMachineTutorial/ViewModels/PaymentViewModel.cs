using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineTutorial.ViewModels
{
    public class PaymentViewModel : ObservableObject
    {
        
        private double _inserted;
        private double _total;
        private double _change;

        public double Inserted
        {
            get
            {
                return _inserted;
            }
            set
            {
                _inserted = value;
                OnPropertyChanged("Inserted");
            }
        }


        //Insert monetary value
        public void Insert(double value)
        {
            Inserted += value;
            
        }

        //Set the total the requested item costs

        public double Total
        {
            get
            {
                return _total;
            }
            set
            {
                _total = value;
                OnPropertyChanged("Total");
            }
        }

        public PaymentViewModel()
        {
            Inserted = 0;
        }

       
    }
}
