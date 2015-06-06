using Entity.Entity;
using HotelClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelClient.ViewModel
{
    public class HotelsViewModel : EntitiesViewModel<Hotel, CreateUpdateHotelWindow, HotelViewModel>
    {
        public HotelsViewModel()
        {
            entityAddress = "api/hotel";
            updateEntityList(null);
        }
    }
}
