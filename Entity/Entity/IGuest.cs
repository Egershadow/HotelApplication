using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public interface IGuest : IBaseEntity
    {
        string GuestName { get; set; }
        IList<HotelJournal> HotelJournals { get; set; }
        int Age { get; set; }
    }
}
