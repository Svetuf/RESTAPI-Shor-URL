// <copyright file="RedirectController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApplication15.Controllers
{
    using System;
    using System.Web.Http;
    using System.Web.Http.Results;
    using WebApplication15.Models;

    /// <summary>
    /// Contains method that redirect from shurt URL.
    /// </summary>
    public class RedirectController : ApiController
    {
        private readonly DbModel redirect = new DbModel();

        /// <summary>
        /// Redirect from short URL
        /// </summary>
        /// <returns>Redirect.</returns>
        [HttpGet]
        public RedirectResult Get(int id)
        {
            RedirectResult ans;
            try
            {
                if (this.redirect.TimeIsGone(id))
                {
                    return this.Redirect(this.Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/api/redirecterror/0");
                }

                ans = this.Redirect(this.redirect.GetRedirectUrl(id));
            }
            catch (Exception)
            {
                ans = this.Redirect(this.Request.RequestUri.GetLeftPart(UriPartial.Authority) + "/api/redirecterror/1");
            }

            return ans;
        }
    }
}
