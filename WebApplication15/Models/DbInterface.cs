﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication15.Models
{
    public class DbInterface
    {
        UrlContext db = new UrlContext();
        public string GetRedirectUrl(int id)
        {
            IEnumerable<ShortUrl> allDb = db.Urls;

            IEnumerable<string> same = from i in allDb where i.ShortLinkInt == id select i.OldUrl;

            return same.First();
        }
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
        public string GetFullLink(int id)
        {
            IEnumerable<string> ans = from i in db.Urls where i.ShortLinkInt == id select i.OldUrl;
            return ans.First();
        }
        public bool TimeIsGone(int id)
        {
            DateTime time = (from i in db.Urls where i.ShortLinkInt == id select i.Date).FirstOrDefault();
            TimeSpan rez = DateTime.UtcNow - time;
            return (rez.TotalMinutes >= 10);
        }
        public UrlContext GetUrlContext()
        {
            return db;
        }
        public void AddNewNote(ShortUrl givenUrl)
        {
            db.Urls.Add(givenUrl);
            db.SaveChanges();
            return;
        }

    }
}