using Entity.Entity;
using FluentNHibernate.Mapping;

namespace Mapping
{
    class HotelMap : ClassMap<Hotel>
    {
        public HotelMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Not.Nullable();
            Map(x => x.HotelName);
            Map(x => x.HotelCity);
        }
    }
}
