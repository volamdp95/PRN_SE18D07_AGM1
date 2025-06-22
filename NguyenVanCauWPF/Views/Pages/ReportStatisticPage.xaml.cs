using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using NguyenVanCau_SE18D07_A01.Repositories.Implements;

namespace NguyenVanCau_SE18D07_A01.Views.Pages
{
    public partial class ReportStatisticPage : Page
    {
        private readonly BookingRepository bookingRepo = new BookingRepository();

        public ReportStatisticPage()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = dpStartDate.SelectedDate ?? DateTime.MinValue;
            DateTime end = dpEndDate.SelectedDate ?? DateTime.MaxValue;

            var result = bookingRepo.GetAll()
                .Where(b => b.BookingDate >= start && b.BookingDate <= end)
                .OrderByDescending(b => b.BookingDate)
                .Select(b => new
                {
                    RoomNumber = b.Room?.RoomNumber ?? "Unknown",
                    CustomerName = b.Customer?.CustomerFullName ?? "Unknown",
                    BookingDate = b.BookingDate,
                    TotalPrice = b.TotalPrice
                })
                .ToList();

            dgReport.ItemsSource = result;
        }
    }
}
