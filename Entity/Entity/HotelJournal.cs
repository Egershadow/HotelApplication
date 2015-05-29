using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class HotelJournal : BaseEntity, IHotelJournal
    {
        public virtual Room Room { get; set; }
        public virtual Guest Guest { get; set; }
        public virtual DateTime date { get; set; }
        public HotelJournal()
        {
            date = DateTime.Now;
        }
    }
}
