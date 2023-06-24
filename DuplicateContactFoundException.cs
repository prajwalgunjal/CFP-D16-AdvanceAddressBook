using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandlingAddresssBook
{
    internal class DuplicateContactFoundException :Exception
    {
        public DuplicateContactFoundException(string msg) {
            Console.WriteLine("THis is exception class ");
        }
        public DuplicateContactFoundException() { }
    }
}
