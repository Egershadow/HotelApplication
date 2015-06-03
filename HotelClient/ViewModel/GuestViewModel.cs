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
        }
    }
}
