using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using WebApplication15.Models;
using System.Web.Http;

namespace WebApplication15.Controllers
{
    public class FullLinkController : ApiController
    {
        DbInterface db = new DbInterface();

        /// <summary>
        /// Return a full URL from your short URL, send it in request body
        /// </summary>
        public string Get([FromBody] int id)
        {
            string ans;
            try
            {
                if(db.TimeIsGone(id))
                {
                    return "Life time is gone";
                }
                ans = db.GetFullLink(id);
            }
            catch(Exception e)
            {
                ans = e.Message;
            }
            return ans;
        }
    }
}
