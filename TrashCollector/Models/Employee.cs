using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
    }
}