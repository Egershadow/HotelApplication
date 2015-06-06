using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Hotel : BaseEntity, IHotel
    {
        public virtual string HotelName { get; set; }
        public virtual string HotelCity { get; set; }
        public virtual IList<Room> Rooms { get; set; }

        public override string ToString()
        {
            return HotelName;
        }
    }
}
