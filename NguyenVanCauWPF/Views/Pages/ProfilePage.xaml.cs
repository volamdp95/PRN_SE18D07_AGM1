using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using NguyenVanCau_SE18D07_A01.Repositories.Implements;
using System.Windows;
using System.Windows.Controls;

namespace NguyenVanCau_SE18D07_A01.Views.Pages
{
    public partial class ProfilePage : Page
    {
        private readonly Customer currentCustomer;
        private readonly CustomerRepository customerRepository = new();

        public ProfilePage(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer;
            LoadProfile();
        }

        private void LoadProfile()
        {
            txtFullName.Text = currentCustomer.CustomerFullName;
            txtEmail.Text = currentCustomer.EmailAddress;
            txtPhone.Text = currentCustomer.Telephone;
            dpBirthday.SelectedDate = currentCustomer.CustomerBirthday;
            txtPassword.Password = currentCustomer.Password;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                dpBirthday.SelectedDate == null ||
                string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            currentCustomer.CustomerFullName = txtFullName.Text.Trim();
            currentCustomer.Telephone = txtPhone.Text.Trim();
            currentCustomer.CustomerBirthday = dpBirthday.SelectedDate.Value;
            currentCustomer.Password = txtPassword.Password;
            currentCustomer.EmailAddress = txtEmail.Text.Trim();

            customerRepository.Update(currentCustomer);

            MessageBox.Show("✅ Cập nhật hồ sơ thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            string message =
                $"👤 Họ tên: {currentCustomer.CustomerFullName}\n" +
                $"📧 Email: {currentCustomer.EmailAddress}\n" +
                $"📱 Số điện thoại: {currentCustomer.Telephone}\n" +
                $"🎂 Ngày sinh: {currentCustomer.CustomerBirthday:dd/MM/yyyy}\n" +
                $"🔒 Mật khẩu: {currentCustomer.Password}";

            MessageBox.Show(message, "Thông tin hồ sơ hiện tại", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
