using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using NguyenVanCau_SE18D07_A01.Views.Pages; 
using System.Windows;

namespace NguyenVanCau_SE18D07_A01.Views
{
    public partial class CustomerDashboardWindow : Window
    {
        private readonly Customer currentCustomer;

        public CustomerDashboardWindow(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer;

            mainFrame.Navigate(new BookRoomPage(currentCustomer));
        }

        private void btnBookRoom_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new BookRoomPage(currentCustomer));
        }

        private void btnProfile_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new ProfilePage(currentCustomer));
        }

        private void btnHistory_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new BookingHistoryPage(currentCustomer));
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
