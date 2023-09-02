﻿namespace ContactsBook.Application.Features.Contact.Queries.GetAllContacts
{
    public class ContactDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string PhoneNumber { get; set; }

        public string Iban { get; set; }
    }
}
