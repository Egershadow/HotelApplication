﻿using Entity.Entity;
using FluentNHibernate.Mapping;

namespace Mapping
{
    class HotelJournalMap : ClassMap<HotelJournal>
    {
        public HotelJournalMap()
        {
            Id(x => x.Id).GeneratedBy.Identity().Not.Nullable();
            Map(x => x.date);
            References(c => c.Guest).Not.LazyLoad();
            References(c => c.Room).Not.LazyLoad();
        }
    }
}
