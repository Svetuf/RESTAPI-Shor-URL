using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebApplication15.Models
{
    /// <summary>
    /// Model of short url in database.
    /// </summary>
    public class ShortUrl
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Generated short link.
        /// </summary>
        public string ShortLink { get; set; }

        /// <summary>
        /// Number of short link.
        /// </summary>
        public int ShortLinkInt { get; set; }

        /// <summary>
        /// Full URL.
        /// </summary>
        public string OldUrl { get; set; }

        /// <summary>
        /// Date of creating note.
        /// </summary>
        public DateTime Date {get;set;}

    }
}