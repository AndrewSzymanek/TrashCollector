using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }

        [DisplayName("Name")]
        public string name { get; set; }

        [DisplayName("Address")]
        public string address { get; set; }

        [DisplayName("City")]
        public string city { get; set; }

        [DisplayName("State")]
        public string state { get; set; }

        [DisplayName("Zip Code")]
        public int zipCode { get; set; }

        [DisplayName("Pickup Day")]
        public string pickupDay { get; set; }

        [DisplayName("Balance")]
        public double balance { get; set; }

        [DisplayName("Extra Pickup Day")]
        public string extraPickupDay { get; set; }

        [DisplayName("Suspension Start Date")]
        public string startDate { get; set; }

        [DisplayName("Suspension End Date")]
        public string endDate { get; set; }
        //[ForeignKey("")]

    }
}