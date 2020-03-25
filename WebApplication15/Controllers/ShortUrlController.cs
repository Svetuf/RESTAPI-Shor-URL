// <copyright file="ShortUrlController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApplication15.Controllers
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Text.RegularExpressions;
    using System.Web.Http;
    using WebApplication15.Models;

    /// <summary>
    /// Contain controllers to create short URL.
    /// </summary>
    public class ShortUrlController : ApiController
    {
        readonly DbModel generator = new DbModel();

        /// <summary>
        /// Create a new short URL, you should send your URL in request body.
        /// </summary>
        /// <returns>string.</returns>
        [HttpGet]
        public string Get([FromBody] string oldUrl)
        {
            Regex regex = new Regex(@"^http(s) ?://([\w-]+.)+[\w-]+(/[\w- ./?%&=])?$", RegexOptions.IgnoreCase);
            if (!regex.IsMatch(oldUrl))
            {
                return "it's not url";
            }

            string ans;
            try
            {
                ans = generator.GetShortUrl(oldUrl, Request.RequestUri.GetLeftPart(UriPartial.Authority));
            }
            catch(Exception e)
            {
                ans = e.Message;
            }

            return ans;
        }

        /// <summary>
        /// Create a new ShortUrl note in database
        /// </summary>
        /// <param name="givenUrl"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody] ShortUrl givenUrl)
        {
            try
            {
                generator.AddNewNote(givenUrl);
                return Request.CreateResponse(HttpStatusCode.OK, "Done");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "can't add note");
            }
        }

        /// <summary>
        /// Update a db note with id, send your new note in request body 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="givenUrl"></param>
        /// <returns></returns>
        public HttpResponseMessage Put(int id, [FromBody] ShortUrl givenUrl)
        {
            try
            {
                ShortUrl oldUrl = generator.GetUrlContext().Urls.Find(id);
                oldUrl = givenUrl;
                generator.GetUrlContext().SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Done");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "can't update note");
            }
        }

        /// <summary>
        /// Delete note with id=id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                ShortUrl foundedNote = generator.GetUrlContext().Urls.Find(id);
                generator.GetUrlContext().Urls.Remove(foundedNote);
                generator.GetUrlContext().SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, "Done");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "can't delete note");
            }
        }
    }
}
