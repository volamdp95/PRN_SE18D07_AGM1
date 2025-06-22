using NguyenVanCau_SE18D07_A01.BusinessObjects.Models;
using System;
using System.Windows;

namespace NguyenVanCau_SE18D07_A01.Views.Dialogs
{
    public partial class RoomDialog : Window
    {
        public Room Room { get; private set; }

        public RoomDialog(Room existingRoom = null)
        {
            InitializeComponent();
            if (existingRoom != null)
            {
                Room = new Room
                {
                    RoomID = existingRoom.RoomID,
                    RoomNumber = existingRoom.RoomNumber,
                    RoomDescription = existingRoom.RoomDescription,
                    RoomMaxCapacity = existingRoom.RoomMaxCapacity,
                    RoomPricePerDate = existingRoom.RoomPricePerDate,
                    RoomStatus = existingRoom.RoomStatus
                };

                txtRoomNumber.Text = Room.RoomNumber;
                txtDescription.Text = Room.RoomDescription;
                txtCapacity.Text = Room.RoomMaxCapacity.ToString();
                txtPrice.Text = Room.RoomPricePerDate.ToString("0.00");
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRoomNumber.Text) || !int.TryParse(txtCapacity.Text, out int capacity) || !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter valid data.");
                return;
            }

            Room ??= new Room();
            Room.RoomNumber = txtRoomNumber.Text.Trim();
            Room.RoomDescription = txtDescription.Text.Trim();
            Room.RoomMaxCapacity = capacity;
            Room.RoomPricePerDate = price;
            Room.RoomStatus = 1;

            DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
