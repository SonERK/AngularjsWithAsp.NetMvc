using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCAngularDemo.Models
{
    public class Province
    {
        [Key]
        public int ProvinceId { get; set; }   

        [MaxLength(100)]
        public string ProvinceName { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Player> Players { get; set; }


    }
}