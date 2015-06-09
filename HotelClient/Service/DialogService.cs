using HotelClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelClient.Service
{
    public class DialogService : IDialogService
    {

        public DialogService()
        {
            
        }

        public bool? ShowDialog(object dialogViewModel)
        {
            Window dialog = MapWindow(dialogViewModel);
            dialog.DataContext = dialogViewModel;

            bool? result;

            try
            {
                result = dialog.ShowDialog();
            }
            catch (Exception e)
            {
                return false;
            }

            return result;
        }

        public Window MapWindow(object ViewModel)
        {
            string typeName = ViewModel.GetType().Name;
            switch (typeName)
            {
                case "GuestViewModel":
                    return new CreateUpdateGuestWindow();               
                case "RoomViewModel":
                    return new CreateUpdateRoomWindow();  
                case "HotelViewModel":
                    return new CreateUpdateHotelWindow();
                case "HotelJournalViewModel":
                    return new CreateUpdateHotelJournalWindow();
                default:
                    return null;
            }         
        }

    }
}
