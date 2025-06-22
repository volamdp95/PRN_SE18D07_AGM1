using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using NguyenVanCau_SE18D07_A01.Repositories.Implements;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace NguyenVanCau_SE18D07_A01.Views.Pages
{
    public partial class RoomManagementPage : Page
    {
        private readonly RoomRepository roomRepository = new RoomRepository();
        private List<Room> allRooms = new();

        public RoomManagementPage()
        {
            InitializeComponent();
            LoadRooms();
        }

        private void LoadRooms()
        {
            allRooms = roomRepository.GetAll()
                .Where(r => r.RoomStatus == 1)
                .ToList();
            dgRooms.ItemsSource = allRooms;
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearch.Text.ToLower().Trim();
            var result = allRooms.Where(r =>
                r.RoomNumber.ToLower().Contains(keyword) ||
                r.RoomDescription.ToLower().Contains(keyword)
            ).ToList();
            dgRooms.ItemsSource = result;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Dialogs.RoomDialog();
            if (dialog.ShowDialog() == true)
            {
                var newRoom = dialog.Room;
                newRoom.RoomStatus = 1;
                roomRepository.Add(newRoom);
                LoadRooms();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is Room selectedRoom)
            {
                var dialog = new Dialogs.RoomDialog(selectedRoom);
                if (dialog.ShowDialog() == true)
                {
                    roomRepository.Update(dialog.Room);
                    LoadRooms();
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is Room selectedRoom)
            {
                var confirm = MessageBox.Show($"Delete room {selectedRoom.RoomNumber}?", "Confirm", MessageBoxButton.YesNo);
                if (confirm == MessageBoxResult.Yes)
                {
                    roomRepository.Delete(selectedRoom.RoomID);
                    LoadRooms();
                }
            }
        }
    }
}
