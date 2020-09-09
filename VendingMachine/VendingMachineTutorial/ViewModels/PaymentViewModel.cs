using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachineTutorial.ViewModels
{
    public class PaymentViewModel : Screen
    {
        
        private double _inserted;

        public double Inserted
        {
            get
            {
                return _inserted;
            }
            set
            {
                _inserted = value;
                NotifyOfPropertyChange(() => Inserted);
            }
        }

        
        public void Insert(double value)
        {
            Inserted += value;
            
        }

        public PaymentViewModel()
        {
            Inserted = 0;
        }
    }
}
