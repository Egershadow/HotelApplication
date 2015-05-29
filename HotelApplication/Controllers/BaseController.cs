using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HotelApplication.DAO;
using Entity;

namespace HotelApplication.Controllers
{
    public class BaseController<ObjType, ObjDAOType> : ApiController where ObjType:BaseEntity where ObjDAOType : IEntityDAO<ObjType, int>, new()

    {
       private readonly ObjDAOType dao;

       public BaseController()
        {
            dao = new ObjDAOType();
        }

        // GET: api/Experts
       public IEnumerable<ObjType> Get()
        {
            return dao.GetAll();
        }

        // GET: api/Experts/5
       public ObjType Get(int id)
        {
            return dao.GetObjectByID(id);
        }

        // POST: api/Experts
       public void Post([FromBody]ObjType value)
        {
            dao.Create(value);
        }

        // PUT: api/Experts/5
       public void Put(int id, [FromBody]ObjType value)
        {
            dao.Update(id, value);
        }

        // DELETE: api/Experts/5
        public void Delete(int id)
        {
            dao.Delete(id);
        }
    }
}
