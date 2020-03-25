// <copyright file="RedirectErrorController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApplication15.Controllers
{
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    /// <summary>
    /// Bad redirrect.
    /// </summary>
    public class RedirectErrorController : ApiController
    {
        /// <summary>
        /// Return BadREquest if id = 1, else return that short URL lifetime is end
        /// </summary>
        /// <returns>Responce.</returns>
        public HttpResponseMessage Get(int id)
        {
            if (id == 1)
                return Request.CreateResponse(HttpStatusCode.BadRequest, "can't redirect");
            else
                return Request.CreateResponse(HttpStatusCode.BadRequest, "lifetime is end");
        }
    }
}
