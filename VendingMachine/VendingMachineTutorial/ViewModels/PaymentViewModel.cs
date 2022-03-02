using Caliburn.Micro;

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
