using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;

namespace MusicStore.Models
{
  

    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }


      
        [Required(ErrorMessageResourceType = typeof(ErrorMessages),
ErrorMessageResourceName = "LastNameRequired")]
        [StringLength(10, ErrorMessageResourceType = typeof(ErrorMessages),
ErrorMessageResourceName = "LastNameTooLong")]
        public string Username { get; set; }




    
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }

        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        public string Email { get; set; }
        public decimal Total { get; set; }

        [Range(18,35)]
        public int Age { get; set; }
        [Range(typeof(decimal),"0.00","100.00")]
        public decimal Price { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }

    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
    }
}