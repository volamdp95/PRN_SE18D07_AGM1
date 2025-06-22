using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Windows;

namespace NguyenVanCau_SE18D07_A01.Views.Dialogs
{
    public partial class CustomerDialog : Window
    {
        public Customer Customer { get; private set; }

        public CustomerDialog()
        {
            InitializeComponent();
            Customer = new Customer();
        }

        public CustomerDialog(Customer existingCustomer)
        {
            InitializeComponent();
            Customer = new Customer
            {
                CustomerID = existingCustomer.CustomerID,
                CustomerFullName = existingCustomer.CustomerFullName,
                Telephone = existingCustomer.Telephone,
                EmailAddress = existingCustomer.EmailAddress,
                CustomerBirthday = existingCustomer.CustomerBirthday,
                Password = existingCustomer.Password,
                CustomerStatus = existingCustomer.CustomerStatus
            };

            txtFullName.Text = Customer.CustomerFullName;
            txtPhone.Text = Customer.Telephone;
            txtEmail.Text = Customer.EmailAddress;
            dpBirthday.SelectedDate = Customer.CustomerBirthday;
            txtPassword.Password = Customer.Password;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Customer.CustomerFullName = txtFullName.Text;
            Customer.Telephone = txtPhone.Text;
            Customer.EmailAddress = txtEmail.Text;
            Customer.CustomerBirthday = dpBirthday.SelectedDate ?? DateTime.Now;
            Customer.Password = txtPassword.Password;
            Customer.CustomerStatus = 1;

            this.DialogResult = true;
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}
