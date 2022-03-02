using System.Windows;
using VendingMachineTutorial.ViewModels;

namespace VendingMachineTutorial
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MachineViewModel _machine = new MachineViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = _machine;
        }

        private void Insert50_Clicked(object sender, RoutedEventArgs e)
        {
            _machine.InsertChange(0.50);
        }

        private void Insert1_Clicked(object sender, RoutedEventArgs e)
        {
            _machine.InsertChange(1);
        }

        private void Insert5_Clicked(object sender, RoutedEventArgs e)
        {
            _machine.InsertChange(5);
        }

        private void BuyItem(object sender, RoutedEventArgs e)
        {
            _machine.AddToBasket();
        }

        private void RemoveFromCart(object sender, RoutedEventArgs e)
        {
            _machine.RemoveFromBasket();
        }

        private void GetYourChange(object sender, RoutedEventArgs e)
        {
            _machine.RetrieveChange();
        }

    }
}
