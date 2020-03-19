using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication15.Controllers
{
    /// <summary>
    /// Bad redirrect.
    /// </summary>
    public class RedirectErrorController : ApiController
    {
        /// <summary>
        /// Return BadREquest if id = 1, else return that short URL lifetime is end
        /// </summary>
        public HttpResponseMessage Get(int id)
        {
            if(id == 1)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "can't redirect");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, "lifetime is end");
        }
    }
}
