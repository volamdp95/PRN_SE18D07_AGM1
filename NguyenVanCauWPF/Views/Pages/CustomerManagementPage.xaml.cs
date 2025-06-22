using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using NguyenVanCau_SE18D07_A01.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NguyenVanCau_SE18D07_A01.Views.Pages
{
    public partial class CustomerManagementPage : Page
    {
        private readonly CustomerRepository customerRepository = new CustomerRepository();
        private List<Customer> allCustomers = new();

        private readonly Customer currentUser; // nếu cần dùng sau này

        public CustomerManagementPage()
        {
            InitializeComponent();
            LoadCustomers();
        }

        public CustomerManagementPage(Customer user) : this()
        {
            currentUser = user;
        }

        private void LoadCustomers()
        {
            allCustomers = customerRepository.GetAll()
                .Where(c => c.CustomerStatus == 1)
                .ToList();

            dgCustomers.ItemsSource = allCustomers;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text.ToLower().Trim();

            var result = allCustomers.Where(c =>
                (c.CustomerFullName != null && c.CustomerFullName.ToLower().Contains(keyword)) ||
                (c.EmailAddress != null && c.EmailAddress.ToLower().Contains(keyword)) ||
                (c.Telephone != null && c.Telephone.ToLower().Contains(keyword))
            ).ToList();

            dgCustomers.ItemsSource = result;
        }


        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Views.Dialogs.CustomerDialog();
            if (dialog.ShowDialog() == true)
            {
                var newCustomer = dialog.Customer;
                newCustomer.CustomerStatus = 1; // Active
                customerRepository.Add(newCustomer);
                LoadCustomers(); // Load lại bảng
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selectedCustomer)
            {
                // Clone dữ liệu gốc tránh sửa trực tiếp
                var clone = new Customer
                {
                    CustomerID = selectedCustomer.CustomerID,
                    CustomerFullName = selectedCustomer.CustomerFullName,
                    EmailAddress = selectedCustomer.EmailAddress,
                    Telephone = selectedCustomer.Telephone,
                    Password = selectedCustomer.Password,
                    CustomerBirthday = selectedCustomer.CustomerBirthday,
                    CustomerStatus = selectedCustomer.CustomerStatus
                };

                var dialog = new Views.Dialogs.CustomerDialog(clone);
                if (dialog.ShowDialog() == true)
                {
                    customerRepository.Update(dialog.Customer);
                    LoadCustomers(); // Load lại bảng
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selectedCustomer)
            {
                var result = MessageBox.Show(
                    $"Do you really want to delete {selectedCustomer.CustomerFullName}?",
                    "Confirm Delete", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    customerRepository.Delete(selectedCustomer.CustomerID);
                    LoadCustomers(); // Load lại bảng
                }
            }
        }
    }
}
