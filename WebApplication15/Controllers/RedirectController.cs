using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using WebApplication15.Models;

namespace WebApplication15.Controllers
{
    /// <summary>
    /// Contains method that redirect from shurt URL.
    /// </summary>
    public class RedirectController : ApiController
    {
        readonly DbInterface redirect = new DbInterface();

        /// <summary>
        /// Redirect from short URL
        /// </summary>
        [HttpGet]
        public RedirectResult Get(int id)
        {
            RedirectResult ans;
            try
            {
                if (redirect.TimeIsGone(id))
                {
                    return Redirect(Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/api/redirecterror/0");
                }
                ans = Redirect(redirect.GetRedirectUrl(id));
            }
            catch (Exception)
            {
                ans = Redirect(Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/api/redirecterror/1");
            }
            return ans;
        }
    }
}
