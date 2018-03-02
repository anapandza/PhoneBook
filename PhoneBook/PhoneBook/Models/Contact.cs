using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class Contact
    {
        public int ContactID { get; set; }

        [Display(Name = "First Name"), Required, StringLength(50)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name"), Required, StringLength(50)]
        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return String.Format("{0} {1}", FirstName, LastName);
            }
        }

        //navigation property connects contact and all phonenumbers each contact has
        //virtual enables lazy loading
        [Display(Name = "Phone Numbers")]
        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }
    }
}