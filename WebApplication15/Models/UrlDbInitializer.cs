using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication15.Models
{
    public class UrlDbInitializer : DropCreateDatabaseAlways<UrlContext>
    {
        protected override void Seed(UrlContext db)
        {
            db.Urls.Add(new ShortUrl { Id = 1, ShortLink = "123", OldUrl = "b", Date = DateTime.Now, ShortLinkInt = 0 }) ;
            db.Urls.Add(new ShortUrl { Id = 2, ShortLink = "1", OldUrl = "b", Date = DateTime.Now, ShortLinkInt = 0 });
            db.Urls.Add(new ShortUrl { Id = 3, ShortLink = "323", OldUrl = "b", Date = DateTime.Now, ShortLinkInt = 0 });

            base.Seed(db);
        }
    }
}