﻿using System;
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
        }
    }
}
