using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExceptionHandlingAddresssBook
{
    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }

        public Contact(string Name, string Email, string Phone, string State, string City, string Zipcode)
        {
            Regex Checkname = new Regex("^[A-Z][a-z]{2,}");
            Match match = Checkname.Match(Name);
            if (match.Success)
            {
                this.Name = Name;
            }
            else
            {
                AddressBook.flag = false;
                Console.WriteLine("not a valid FirstName");
            }

            Regex CheckEmail = new Regex("^\\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}\\b");

            if (CheckEmail.IsMatch(Email))
            {
                this.Email = Email;
            }
            else
            {
                AddressBook.flag = false;
                Console.WriteLine("not a valid Email");
            }
            
            Regex Phoneno = new Regex("^(\\+?\\d{1,3})\\s\\d{10}$");

            if (Phoneno.IsMatch(Phone))
            {
                this.Phone = Phone;
            }
            else
            {
                AddressBook.flag = false;
                Console.WriteLine("not a valid Phone Number");
            }
            this.State = State;
            this.City = City;
            this.Zipcode = Zipcode;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nEmail: {Email}\nPhone: {Phone}\nState: {State}\nCity: {City}\nZip: {Zipcode}";
        }

    }
}