using Entity.Entity;
using FluentNHibernate.Mapping;

namespace Mapping
{
    class RoomMap : ClassMap<Room>
    {
        public RoomMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Not.Nullable();
            Map(x => x.RoomNumber);
            Map(x => x.RoomType);
            References(c => c.HotelOwner).Not.LazyLoad();
        }
    }
}
