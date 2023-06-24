using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingAddresssBook
{
    internal class AddressBook
    {
        List<Contact> contactList = new List<Contact>();
        public void addContact()
        {
            Console.WriteLine("Enter name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter phone");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter state");
            string state = Console.ReadLine();
            Console.WriteLine("Enter city");
            string city = Console.ReadLine();
            Console.WriteLine("Enter zip");
            string zip = Console.ReadLine();
            Contact contact = new Contact(name, email, phone, state, city, zip);
            bool isDuplicate = false;
            foreach (Contact existingContact in contactList)
            {
                if (existingContact.Phone == phone)
                {
                    isDuplicate = true;
                    break;
                }
            }
            if (!isDuplicate)
            {
                contactList.Add(contact);
                Console.WriteLine("Contact added..");
            }
            else
            {
                Console.WriteLine("Duplicate Phone Number....");
            }
        }

        public void Display()
        {
            foreach (Contact contact in contactList)
            {
                Console.WriteLine(contact);
            }
        }

        public void delete()
        {
            Console.WriteLine("Enter name of the contact: ");
            string input = Console.ReadLine();
            for (int i = 0; i < contactList.Count; i++)
            {
                Contact contact = contactList[i];
                if (input == contact.Name)
                {
                    contactList.Remove(contact);
                    Console.WriteLine("Contact deleted ....");
                    return;
                }
            }
            Console.WriteLine($"{input} not found in addressBook");
        }

        public void Edit()
        {
            Console.WriteLine("Enter name of the contact: ");
            string input = Console.ReadLine();
            for (int i = 0; i < contactList.Count; i++)
            {
                Contact contact = contactList[i];
                if (input == contact.Name)
                {
                    Console.WriteLine("Enter name");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter email");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter phone");
                    string phone = Console.ReadLine();
                    Console.WriteLine("Enter state");
                    string state = Console.ReadLine();
                    Console.WriteLine("Enter city");
                    string city = Console.ReadLine();
                    Console.WriteLine("Enter zip");
                    string zip = Console.ReadLine();
                    contact.Name = name;
                    contact.Email = email;
                    contact.Phone = phone;
                    contact.State = state;
                    contact.City = city;
                    contact.Zipcode = zip;
                    Console.WriteLine("Contact Updated..");
                    return;
                }
            }
        }
    }
}
