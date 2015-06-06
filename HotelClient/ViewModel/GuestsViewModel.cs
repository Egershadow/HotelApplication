using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using HotelClient.View;
using HotelClient.Model;
using System.Collections.ObjectModel;

namespace HotelClient.ViewModel
{
    public class GuestsViewModel : EntitiesViewModel<Guest, CreateUpdateGuestWindow,GuestViewModel>
    {
        public GuestsViewModel()
        {
            entityAddress = "api/guest";
            updateEntityList(null);
            //Guest guest = new Guest();
            //guest.Id = 1;
            //guest.Age = 20;
            //guest.GuestName = "Vadim";
            //Entities.Add(guest);

            //Guest guest1 = new Guest();
            //guest1.Id = 2;
            //guest1.Age = 22;
            //guest1.GuestName = "Superman";
            //Entities.Add(guest1);
        }
    }
}
