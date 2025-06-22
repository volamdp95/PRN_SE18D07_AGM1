
using System.Windows;

namespace NguyenVanCau_SE18D07_A01.Views
{
    public partial class AdminDashboardWindow : Window
    {
        public AdminDashboardWindow(BusinessObjects.Models.Customer user)
        {
            InitializeComponent();
        }

        private void btnCustomerManagement_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Views.Pages.CustomerManagementPage()); 
        }

        private void btnRoomManagement_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Views.Pages.RoomManagementPage());
        }

        private void btnReports_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Views.Pages.ReportStatisticPage()); 
        }

        //private void btnLogout_Click(object sender, RoutedEventArgs e)
        //{
        //    this.Close(); // hoặc chuyển về LoginWindow
        //}
    }
}
