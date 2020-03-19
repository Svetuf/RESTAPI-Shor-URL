using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication15.Models
{
    /// <summary>
    /// Database context.
    /// </summary>
    public class UrlContext : DbContext
    {
        /// <summary>
        /// Data.
        /// </summary>
        public DbSet<ShortUrl> Urls { get; set; }
    }
}