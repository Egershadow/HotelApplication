using Entity.Entity;
using HotelClient.Service;
using HotelClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelClient.ViewModel
{
    public class HotelsViewModel : EntitiesViewModel<Hotel, DialogService, HotelViewModel>
    {
        public HotelsViewModel()
        {
            entityAddress = "api/hotel";
            updateEntityList(null);
        }
    }
}
