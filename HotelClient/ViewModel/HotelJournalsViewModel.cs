using Entity.Entity;
using HotelClient.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelClient.ViewModel
{
    public class HotelJournalsViewModel : EntitiesViewModel<HotelJournal, CreateUpdateHotelJournalWindow, HotelJournalViewModel>
    {
        public HotelJournalsViewModel()
        {
            entityAddress = "api/hoteljournal";
            updateEntityList(null);
        }
    }
}

