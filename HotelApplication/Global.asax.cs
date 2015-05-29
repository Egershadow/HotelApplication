using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NHibernate;
using NHibernate.Context;

namespace HotelApplication
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        private static ISessionFactory sessionFactory;
        public static ISessionFactory SessionFactory
        {
            get
            {
                return sessionFactory;
            }
        }

        public override void Init()
        {
            this.BeginRequest += (sender, e) =>
            {
                var session = sessionFactory.OpenSession();
                CurrentSessionContext.Bind(session);
            };

            this.EndRequest += (sender, e) =>
            {
                var session = CurrentSessionContext.Unbind(sessionFactory);
                session.Dispose();
            };

            base.Init();
        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            sessionFactory = Configuration.NHibernateHelper.InitializeSessionFactory();
        }
    }
}