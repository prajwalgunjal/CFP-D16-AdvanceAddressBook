using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingAddresssBook
{
    internal class ContactNotFoundException : Exception
    {
        public ContactNotFoundException() { }
        public ContactNotFoundException(string msg)
        {
            Console.WriteLine("This is exception class.... Contact not found");
        }

    }
}
