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
        public string Name;
        public string Email;
        public string Phone;
        public string State;
        public string City;
        public string Zipcode;

        public Contact(string name, string email, string phone, string state, string city, string zipcode)
        {
            Regex Checkname = new Regex("^[A-Z][a-z]{2,}");
            Match match = Checkname.Match(name);
            if (match.Success)
            {
                this.Name = name;
            }
            else
            {
                AddressBook.flag = false;
                Console.WriteLine("not a valid FirstName");
            }

            Regex CheckEmail = new Regex("^\\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}\\b");

            if (CheckEmail.IsMatch(email))
            {
                this.Email = email;
            }
            else
            {
                AddressBook.flag = false;
                Console.WriteLine("not a valid Email");
            }

            Regex Phone = new Regex("^(\\+?\\d{1,3})\\s\\d{10}$");

            if (Phone.IsMatch(phone))
            {
                this.Phone = phone;
            }
            else
            {
                AddressBook.flag = false;
                Console.WriteLine("not a valid Phone Number");
            }
            this.State = state;
            this.City = city;
            this.Zipcode = zipcode;
        }
        public override string ToString()
        {
            return $"Name: {Name}\nEmail: {Email}\nPhone: {Phone}\nState: {State}\nCity: {City}\nZip: {Zipcode}";
        }

    }
}
