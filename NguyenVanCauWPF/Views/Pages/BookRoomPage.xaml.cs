using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using NguyenVanCau_SE18D07_A01.DataAccess;
using NguyenVanCau_SE18D07_A01.NguyenVanCauWPF.ViewModels;
using NguyenVanCau_SE18D07_A01.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NguyenVanCau_SE18D07_A01.Views.Pages
{
    public partial class BookRoomPage : Page
    {
        private readonly Customer currentCustomer;
        private readonly RoomRepository roomRepository = new();
        private List<Room> availableRooms = new();
        private DateTime from;
        private DateTime to;

        public BookRoomPage(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer;
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if (dpFrom.SelectedDate == null || dpTo.SelectedDate == null)
            {
                MessageBox.Show("Please select both start and end dates.");
                return;
            }

            from = dpFrom.SelectedDate.Value;
            to = dpTo.SelectedDate.Value;

            if (from >= to)
            {
                MessageBox.Show("End date must be after start date.");
                return;
            }

            var allRoomTypes = RoomTypeDAO.Instance.GetAll();
            availableRooms = roomRepository.GetAvailableRooms(from, to);

            var roomVMs = availableRooms.Select(r =>
            {
                var type = allRoomTypes.FirstOrDefault(t => t.RoomTypeID == r.RoomTypeID);
                return new RoomViewModel
                {
                    RoomNumber = r.RoomNumber,
                    RoomTypeName = type?.RoomTypeName ?? "Unknown",
                    RoomDescription = r.RoomDescription,
                    PriceDisplay = r.RoomPricePerDate.ToString("N0") + " VND",
                    OriginalRoom = r
                };
            }).ToList();

            dgAvailableRooms.ItemsSource = roomVMs;
        }

        private void btnBook_Click(object sender, RoutedEventArgs e)
        {
            if (((Button)sender).DataContext is RoomViewModel selectedRoomVM)
            {
                var room = selectedRoomVM.OriginalRoom;
                int days = (to - from).Days;
                decimal totalPrice = room.RoomPricePerDate * days;

                var booking = new Booking
                {
                    Customer = currentCustomer,
                    Room = room,
                    StartDate = from,       // Thêm dòng này
                    EndDate = to,           // Thêm dòng này
                    TotalPrice = totalPrice,
                    BookingDate = DateTime.Now
                };

                BookingDAO.Instance.Add(booking);

                MessageBox.Show(
                    $"✅ Đặt phòng {room.RoomNumber} thành công!\n" +
                    $"- Khách: {currentCustomer.CustomerFullName}\n" +
                    $"- Từ ngày: {from:dd/MM/yyyy} ➤ đến ngày: {to:dd/MM/yyyy}\n" +
                    $"- Tổng tiền: {totalPrice:N0} VND\n" +
                    $"- Ngày đặt: {DateTime.Now:dd/MM/yyyy HH:mm}"
                );
            }
        }


    }
}
