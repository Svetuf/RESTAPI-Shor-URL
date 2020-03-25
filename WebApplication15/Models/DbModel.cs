// <copyright file="DbModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace WebApplication15.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Data base interface.
    /// </summary>
    public class DbModel
    {
        readonly UrlContext db = new UrlContext();

        /// <summary>
        /// Return full URL from id.
        /// </summary>
        /// <returns>string.</returns>
        public string GetRedirectUrl(int id)
        {
            IEnumerable<ShortUrl> allDb = db.Urls;

            IEnumerable<string> same = from i in allDb where i.ShortLinkInt == id select i.OldUrl;

            return same.First();
        }

        /// <summary>
        /// Add and create new short URL.
        /// </summary>
        public string GetShortUrl(string OldUrl, string myHost)
        {
            IEnumerable<ShortUrl> same = from i in db.Urls where i.OldUrl == OldUrl select i;

            if (same.Count() > 0)
            {
                return same.First().ShortLink;
            }
            else
            {
                ShortUrl newUrl = new ShortUrl { Date = DateTime.UtcNow, OldUrl = OldUrl, ShortLink = myHost + "/api/redirect/" + OldUrl.GetHashCode(), ShortLinkInt = OldUrl.GetHashCode() };
                db.Urls.Add(newUrl);
                db.SaveChanges();
                return newUrl.ShortLink;
            }
        }

        /// <summary>
        /// Return full URL from id.
        /// </summary>
        public string GetFullLink(int id)
        {
            IEnumerable<string> ans = from i in db.Urls where i.ShortLinkInt == id select i.OldUrl;
            return ans.First();
        }

        /// <summary>
        /// Return full URL from id string.
        /// </summary>
        public string GetFullLink(string id)
        {
            IEnumerable<string> ans = from i in db.Urls where i.ShortLink == id select i.OldUrl;
            return ans.First();
        }

        /// <summary>
        /// Return true if short URL time is end.
        /// </summary>
        public bool TimeIsGone(int id)
        {
            DateTime time = (from i in db.Urls where i.ShortLinkInt == id select i.Date).FirstOrDefault();
            TimeSpan rez = DateTime.UtcNow - time;
            return rez.TotalMinutes >= 10;
        }

        /// <summary>
        /// Returns URL context.
        /// </summary>
        public UrlContext GetUrlContext()
        {
            return db;
        }

        /// <summary>
        /// Adding new note.
        /// </summary>
        public void AddNewNote(ShortUrl givenUrl)
        {
            db.Urls.Add(givenUrl);
            db.SaveChanges();
            return;
        }

    }
}