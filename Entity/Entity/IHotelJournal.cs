using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public interface IHotelJournal: IBaseEntity
    {
        Room Room { get; set; }
        Guest Guest { get; set; }
        DateTime date { get; set; }
    }
}
