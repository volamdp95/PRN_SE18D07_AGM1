using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using NguyenVanCau_SE18D07_A01.DataAccess;
using NguyenVanCau_SE18D07_A01.NguyenVanCauWPF.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NguyenVanCau_SE18D07_A01.Views.Pages
{
    public partial class BookingHistoryPage : Page
    {
        private readonly Customer currentCustomer;

        public BookingHistoryPage(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer;
            LoadBookings();
        }

        private void LoadBookings()
        {
            var roomTypes = RoomTypeDAO.Instance.GetAll();
            var bookings = BookingDAO.Instance.GetByCustomer(currentCustomer);

            if (bookings.Count == 0)
            {
                dgHistory.Visibility = Visibility.Collapsed;
                txtNoBooking.Visibility = Visibility.Visible;
            }
            else
            {
                dgHistory.Visibility = Visibility.Visible;
                txtNoBooking.Visibility = Visibility.Collapsed;

                var bookingVMs = bookings.Select(b =>
                {
                    var type = roomTypes.FirstOrDefault(t => t.RoomTypeID == b.Room.RoomTypeID);
                    return new BookingViewModel
                    {
                        RoomNumber = b.Room.RoomNumber,
                        RoomTypeName = type?.RoomTypeName ?? "Unknown",
                        RoomDescription = b.Room.RoomDescription,
                        StartDate = b.StartDate,
                        EndDate = b.EndDate,
                        TotalPrice = b.TotalPrice,
                        OriginalBooking = b
                    };
                }).ToList();

                dgHistory.ItemsSource = bookingVMs;
            }
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is BookingViewModel vm)
            {
                var result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn hủy đặt phòng {vm.RoomNumber} từ {vm.StartDate:dd/MM/yyyy} đến {vm.EndDate:dd/MM/yyyy}?",
                    "Xác nhận hủy đặt phòng",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Warning);

                if (result == MessageBoxResult.Yes)
                {
                    BookingDAO.Instance.Delete(vm.OriginalBooking.BookingID);
                    LoadBookings(); // refresh lại danh sách
                    MessageBox.Show("❌ Đã hủy đặt phòng!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }
}
