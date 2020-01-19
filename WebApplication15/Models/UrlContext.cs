using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication15.Models
{
    public class UrlContext : DbContext
    {
        public DbSet<ShortUrl> Urls { get; set; }
    }
}