using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int id { get; set; }

        [DisplayName ("Name")]
        public string name { get; set; }
        [DisplayName ("Zip Code")]
        public int zipCode { get; set; }
        [DisplayName("Balance")]
        public double balance { get; set; }

        [ForeignKey("ApplicationUser")]
        public string ApplicationId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}