using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Entity;
using HotelClient.View;

namespace HotelClient.ViewModel
{
    public class GuestViewModel : EntitiesViewModel<Guest, CreateUpdateGuestWindow>
    {
        public GuestViewModel()
        {
            entityAddress = "api/guest";

            Guest guest = new Guest();
            guest.Id = 1;
            guest.Age = 20;
            guest.GuestName = "Vadim";
            Entities.Add(guest);

            Guest guest1 = new Guest();
            guest1.Id = 2;
            guest1.Age = 22;
            guest1.GuestName = "Superman";
            Entities.Add(guest1);
        }
    }
}
