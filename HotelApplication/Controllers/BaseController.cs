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
       public HttpResponseMessage Get(int id)
        {
            if (id < 0)
            {
                var resp = Request.CreateResponse(HttpStatusCode.BadRequest);
                resp.ReasonPhrase = "Wrong id!";
                return resp;
            }
            else
            {
                var result = dao.GetObjectByID(id);
                if (result == null)
                {
                    var resp = Request.CreateResponse(HttpStatusCode.BadRequest);
                    resp.ReasonPhrase = "Entity with same id not found!";
                    return resp;
                }
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            
        }

        // POST: api/Experts
       public HttpResponseMessage Post([FromBody]ObjType value)
        {
            bool failed = false;
            int id = value.Id;
            try
            {
                dao.Create(value);
                if (dao.GetObjectByID(id) == null)
                {
                    failed = true;
                }
            }
            catch (Exception e)
            {
                failed = true;
            }

            if (failed)
            {
                var resp = Request.CreateResponse(HttpStatusCode.BadRequest);
                resp.ReasonPhrase = "Creating of entity failed!";
                return resp;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        // PUT: api/Experts/5
       public HttpResponseMessage Put(int id, [FromBody]ObjType value)
        {
            if (id < 0)
            {
                var message = "Wrong id!";
                HttpError err = new HttpError(message);
                return Request.CreateResponse(HttpStatusCode.BadRequest, err);
            }
            else
            {
                var result = dao.GetObjectByID(id);
                if (result == null)
                {
                    var resp = Request.CreateResponse(HttpStatusCode.BadRequest);
                    resp.ReasonPhrase = "Entity with same id not found!";
                    return resp;
                }
                dao.Update(id, value);
                return Request.CreateResponse(HttpStatusCode.OK, result);   
            }       
        }

        // DELETE: api/Experts/5
       public HttpResponseMessage Delete(int id)
        {
            if (id < 0)
            {
                var resp = Request.CreateResponse(HttpStatusCode.BadRequest);
                resp.ReasonPhrase = "Wrong id!";
                return resp;
            }
            else
            {
                var result = dao.GetObjectByID(id);
                if (result == null)
                {
                    var resp = Request.CreateResponse(HttpStatusCode.BadRequest);
                    resp.ReasonPhrase = "Entity with same id not found!";
                    return resp;
                }
                dao.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            } 
            
        }
    }
}
