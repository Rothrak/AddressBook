using AddressBook.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddressBook.Domain.Entity
{
    public class Address : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Location { get; set; }
        public int ContactId { get; set; }
        public Address()
        {

        }
        public Address(int id, string name, string surname, string location, int contactId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Location = location;
            ContactId = contactId;
        }
    }
}
