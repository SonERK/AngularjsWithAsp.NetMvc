using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAngularDemo.Models
{
    public class Country
    {
        [Key]
        public int CountryId { get; set; }

        [MaxLength(100)]
        public string CountryName { get; set; }

        public virtual ICollection<Province> Provinces { get; set; }
        public virtual ICollection<Player> Players { get; set; }

    }
}