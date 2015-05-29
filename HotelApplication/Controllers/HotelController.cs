using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entity.Entity;
using HotelApplication.DAO;

namespace HotelApplication.Controllers
{
    public class HotelController : BaseController<Hotel, HotelDAO>
    {
    }
}
