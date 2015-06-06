using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using Mapping;
using NHibernate;
using NHibernate.Context;

namespace HotelApplication.Configuration
{
    public static class NHibernateHelper
    {
        public static ISessionFactory InitializeSessionFactory()
        {
            return Fluently.Configure().Database(
                 MySQLConfiguration.Standard.ConnectionString(
                    c => c.FromConnectionStringWithKey("ConnectionString"))
                ).Mappings(m => m.FluentMappings.AddFromAssemblyOf<GuestMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<RoomMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelMap>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<HotelJournalMap>())
                .CurrentSessionContext<WebSessionContext>()
                //.ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true,true))
                .BuildSessionFactory();
        }
    }
}