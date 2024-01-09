using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contacts.Models
{
    public static class ContactsRepository
    {
        public static List<Contacts> contacts = new List<Contacts>()
        {
            new Contacts { ContactId = 1, Name = "John Doe", Email = "johndoe@gmail.com" },
            new Contacts { ContactId = 2, Name = "John Doe", Email = "johndoe@gmail.com" },
            new Contacts { ContactId = 3, Name = "John Doe", Email = "johndoe@gmail.com" }
        };
        public static List <Contacts> getList()
        {
            return contacts;
        }
        public static Contacts getContactById(int contactId) {
            var contact = contacts.FirstOrDefault(x => x.ContactId == contactId);
            if(contact != null)
            {
                return new Contacts
                {
                    ContactId = contact.ContactId,
                    Name = contact.Name,
                    Email = contact.Email,
                    PhoneNumber = contact.PhoneNumber,
                    Address = contact.Address
                };
            }
            return null;
        }
        public static void UpdateContact(Contacts contact, int contactId) {
            if (contactId != contact.ContactId) return;
            var contactToUpdate = contacts.FirstOrDefault(x => x.ContactId == contactId);
            if (contactToUpdate != null)
            {
                contactToUpdate.Name = contact.Name;
                contactToUpdate.Email = contact.Email;
                contactToUpdate.Address = contact.Address;
                contactToUpdate.PhoneNumber = contact.PhoneNumber;
            }
        }
        public static void AddContact(Contacts contact)
        {
            var maxId = contacts.Max(x => x.ContactId);
            contact.ContactId = maxId + 1;
            contacts.Add(contact);
        }
        public static void RemoveContact (int ContactId)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == ContactId);
            if( contact != null)
            {
                contacts.Remove(contact);
            }
        }
        public static List<Contacts> SearchContacts(string filterText)
        {
            var contact = contacts.Where(x => !string.IsNullOrEmpty(x.Name) && x.Name.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            if(contact == null || contact.Count == 0)
            {
                contact = contacts.Where(x => !string.IsNullOrEmpty(x.Email) && x.Email.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            }
            else
            {
                return contact;
            }
            if (contact == null || contact.Count == 0)
            {
                contact = contacts.Where(x => !string.IsNullOrEmpty(x.PhoneNumber) && x.PhoneNumber.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            }
            else
            {
                return contact;
            }
            if (contact == null || contact.Count == 0)
            {
                contact = contacts.Where(x => !string.IsNullOrEmpty(x.Address) && x.Address.StartsWith(filterText, StringComparison.OrdinalIgnoreCase))?.ToList();
            }
            else
            {
                return contact;
            }
            return contact;
        }
    }
}
