using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.Name = name;
            this.Email = email;
            this.Phone = phone;
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
