using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PartyInvites.Models
{
    
    public class GuestResponse
    {        
        private string nickname = "";
       
        [Required(ErrorMessage = "Name is mandatory")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is mandatory")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Phone is mandatory")]
        [RegularExpression("[0-9]{5}", ErrorMessage = "Please enter a valid phone")]
        public string Phone { get; set; }        
        public string Nickname
        {
            get
            {
                return nickname;
            }
            set
            {
                nickname = !string.IsNullOrEmpty(value) ? value : Name;
            }
        }
        [Required(ErrorMessage = "Specify attendance")]
        public bool? WillAttend { get; set; }
    }
}
