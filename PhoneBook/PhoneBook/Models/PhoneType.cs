using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class PhoneType
    {
        public int PhoneTypeID { get; set; }

        [Required]
        public string Type { get; set; }

        //navigation property connects contact and all phonenumbers contact has
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}