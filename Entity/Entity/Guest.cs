using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Guest : BaseEntity, IGuest
    {
        public virtual string GuestName { get; set; }
        public virtual IList<HotelJournal> HotelJournals { get; set; }
        public virtual int Age { get; set; }
        public override string ToString()
        {
            return GuestName;
        }
    }
}
