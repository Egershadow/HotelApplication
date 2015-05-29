using System;
using System.Collections.Generic;
using System.Linq;
using NHibernate;
//using Data.Domain;
using NHibernate.Criterion;
//using Data.Domain.Utils;
using Entity;
using HotelApplication;

namespace HotelApplication.DAO
{
    public abstract class BaseEntityDAO<ObjType, KeyType> : IEntityDAO<ObjType, KeyType>
        where ObjType : BaseEntity
                                   where KeyType : struct
    {
        private readonly ISession currentSession;

        protected BaseEntityDAO()
        {
            currentSession = MvcApplication.SessionFactory.GetCurrentSession();
        }

        public IEnumerable<ObjType> GetAll()
        {
            var criteria = this.currentSession.CreateCriteria(typeof(ObjType));
            return criteria.List<ObjType>();
        }

        public ObjType GetObjectByID(KeyType key)
        {
            return this.currentSession.CreateCriteria(typeof(ObjType)).Add(Restrictions.Eq("Id", key)).UniqueResult<ObjType>();          
        }

        public void Create(ObjType obj)
        {
            using (var transaction = this.currentSession.BeginTransaction())
            {
                try
                {
                    this.currentSession.Save(obj);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
             }
        }

        public void Update(KeyType key, ObjType obj)
        {
            if (obj == null)
                return;
            var loadedObj = this.currentSession.CreateCriteria(typeof(ObjType)).Add(Restrictions.Eq("Id", key)).UniqueResult<ObjType>();
            using (var transaction = this.currentSession.BeginTransaction())
            {
                try
                {
                    int id = loadedObj.Id;
                    EntityService.CopyAllPropertiesFrom<ObjType>(loadedObj, obj);
                    loadedObj.Id = id;
                    this.currentSession.Update(loadedObj);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
            }
                
                    
        }

        public void Delete(KeyType key)
        {
            using (var transaction = this.currentSession.BeginTransaction())
            {

                var obj = (ObjType)this.currentSession.Load(typeof(ObjType), key);

                if(obj != null)
                {
                    try
                    {
                        this.currentSession.Delete(obj);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                    }
                }
                
            }
        }
    }
}