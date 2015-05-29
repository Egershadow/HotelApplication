using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Room : BaseEntity, IRoom
    {
        public virtual int RoomNumber { get; set; }
        public virtual string RoomType { get; set; }
        public virtual Hotel HotelOwner { get; set; }
        public virtual IList<HotelJournal> HotelJournals { get; set; }
    }
}
