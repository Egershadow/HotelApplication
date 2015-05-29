using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public interface IHotel : IBaseEntity
    {
        string HotelName { get; set; }
        string HotelCity { get; set; }
        IList<Room> Rooms { get; set; }
    }
}
