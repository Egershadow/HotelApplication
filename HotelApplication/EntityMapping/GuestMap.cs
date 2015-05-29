using Entity.Entity;
using FluentNHibernate.Mapping;

namespace Mapping
{
    class GuestMap : ClassMap<Guest>
    {
        public GuestMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Not.Nullable();
            Map(x => x.GuestName);
            Map(x => x.Age);
        }
    }
}
