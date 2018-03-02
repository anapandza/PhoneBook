using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class PhoneNumber
    {
        public int PhoneNumberID { get; set; }

        public int ContactID { get; set; }

        public int PhoneTypeID { get; set; }

        [Required]
        public string Number { get; set; } //string beacuse it contains space if it is in this format +385 99 123 456

        public bool Default { get; set; }

        //navigation properties connect contact and phone type with phone number
        public virtual Contact Contact { get; set; }

        [Display(Name = "Phone Type")]
        public virtual PhoneType PhoneType { get; set; }
    }
}