using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models
{
    public class Order
    {
        [BindNever]
        public int OrderID { get; set; }

        [BindNever]
        IEnumerable<CartLine> Lines { get; set; }

        [Required(ErrorMessage = "Address!")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Name!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country!")]
        public string Country { get; set; }

        [Required(ErrorMessage = "City!")]
        public string City { get; set; }

        public string ZipCode { get; set; }

        public bool Wrap { get; set; }
    }
}
