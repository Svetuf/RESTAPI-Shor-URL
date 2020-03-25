// <copyright file="FullLinkController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApplication15.Controllers
{
    using System;
    using System.Web.Http;
    using log4net;
    using WebApplication15.Models;

    /// <summary>
    /// Contains method than return full URL.
    /// </summary>
    public class FullLinkController : ApiController
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(FullLinkController));

        private readonly DbModel db = new DbModel();

        /// <summary>
        /// Return a full URL from your short URL, send it in request body.
        /// </summary>
        /// <returns>string URL.</returns>
        public string Get([FromBody] int id)
        {
            string ans;
            Log.Debug("Try find a URL...");
            try
            {
                if (this.db.TimeIsGone(id))
                {
                    return "Life time is gone";
                }

                ans = this.db.GetFullLink(id);
            }
            catch (Exception e)
            {
                ans = e.Message;
            }

            return ans;
        }
    }
}
