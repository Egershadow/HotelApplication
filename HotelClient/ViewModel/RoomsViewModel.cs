﻿using Entity.Entity;
using HotelClient.Service;
using HotelClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelClient.ViewModel
{
    public class RoomsViewModel : EntitiesViewModel<Room, DialogService, RoomViewModel>
    {
        public RoomsViewModel()
        {
            entityAddress = "api/room";
            updateEntityList(null);
        }
    }
}
