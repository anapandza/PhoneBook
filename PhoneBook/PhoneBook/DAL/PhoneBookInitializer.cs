using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using PhoneBook.Models;

namespace PhoneBook.DAL
{
    public class PhoneBookInitializer : DropCreateDatabaseIfModelChanges<PhoneBookContext>
    {
        protected override void Seed(PhoneBookContext context)
        {
            var contacts = new List<Contact>
            {
                new Contact { FirstName="John", LastName="Smith", Address="900 Nautilus Avenue, London", Email="john.smith@gmail.com" },
                new Contact { FirstName="Alice", LastName="Fox", Address="269 Newton Street, Cardiff", Email="alice.fox@gmail.com" },
                new Contact { FirstName="Dan", LastName="McKee", Address="494 Beacon Court, Dublin", Email="dan.mckee@gmail.com" },
                new Contact { FirstName="Alan", LastName="Rotger", Address="663 Berkeley Place, Oxford", Email="alan.rotger@gmail.com" },
                new Contact { FirstName="Eliza", LastName="Mays", Address="889 Windsor Place, London", Email="eliza.mays@gmail.com" }
            };

            contacts.ForEach(s => context.Contacts.Add(s));
            context.SaveChanges();

            var phoneTypes = new List<PhoneType>
            {
                new PhoneType { Type="Telephone" },
                new PhoneType { Type="Mobilephone" },
                new PhoneType { Type="Fax" }
            };

            phoneTypes.ForEach(s => context.PhoneTypes.Add(s));
            context.SaveChanges();

            var phoneNumbers = new List<PhoneNumber>
            {
                new PhoneNumber { Number="+385 1 526 2997", ContactID=1, PhoneTypeID=1, Default= true },
                new PhoneNumber { Number="+385 1 526 2998", ContactID=1, PhoneTypeID=3, Default= false },
                new PhoneNumber { Number="+385 99 550 2712", ContactID=2, PhoneTypeID=2, Default= true },
                new PhoneNumber { Number="+385 91 672 3050", ContactID=3, PhoneTypeID=2, Default= true },
                new PhoneNumber { Number="+385 21 536 745", ContactID=4, PhoneTypeID=1, Default= true },
                new PhoneNumber { Number="+385 21 536 744", ContactID=4, PhoneTypeID=3, Default= false },
                new PhoneNumber { Number="+385 20 308 221", ContactID=5, PhoneTypeID=1, Default= true }
            };

            phoneNumbers.ForEach(s => context.PhoneNumbers.Add(s));
            context.SaveChanges();
        }


    }
}