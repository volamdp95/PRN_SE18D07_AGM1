using NguyenVanCau_SE18D07_A01.Repositories.Implements;
using NguyenVanCau_SE18D07_A01.Views;
using System.Windows;

namespace NguyenVanCau_SE18D07_A01
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Password;

            var repo = new CustomerRepository();
            var user = repo.GetByEmail(email);

            if (user != null && user.Password == password && user.CustomerStatus == 1)
            {
                if (user.EmailAddress == "admin@FUMiniHotelSystem.com")
                {
                    new AdminDashboardWindow(user).Show();
                }
                else
                {
                    new CustomerDashboardWindow(user).Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }

        private void txtEmail_TextChanged_1(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
