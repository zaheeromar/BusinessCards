using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BusinessCards.Models
{
    public class BusinessCard
    {
        public int ID { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string Number { get; set; }
        public string Email { get; set; }
    }

    public class BusinessCardDBContext : DbContext
    {
        public DbSet<BusinessCard> BusinessCards { get; set; }
    }
}