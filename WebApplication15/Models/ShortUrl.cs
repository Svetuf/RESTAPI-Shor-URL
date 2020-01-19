using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace WebApplication15.Models
{
    public class ShortUrl
    {
        [Key]
        public int Id { get; set; }
        public string ShortLink { get; set; }
        public int ShortLinkInt { get; set; }
        public string OldUrl { get; set; }
        public DateTime Date {get;set;}

    }
}