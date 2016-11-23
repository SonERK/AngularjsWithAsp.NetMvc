using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCAngularDemo.Models
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [MaxLength(75)]
        public string Name { get; set; }
        public DateTime RegisterationDate { get; set; }
        [MaxLength(75)]
        public string MailAddress { get; set; }
        [MaxLength(15)]
        public string Phone { get; set; }
        public decimal Point { get; set; }
        public int? CountryId { get; set; }
        public int? ProvinceId { get; set; }
        public bool IsActive { get; set; }

        public virtual Country Country { get; set; }
        public virtual Province Province { get; set; }
        

    }
}