using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public interface IRoom : IBaseEntity
    {
        int RoomNumber { get; set; }
        string RoomType { get; set; }
        Hotel HotelOwner { get; set; }
        IList<HotelJournal> HotelJournals { get; set; }
    }
}
