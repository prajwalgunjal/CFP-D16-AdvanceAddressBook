using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ExceptionHandlingAddresssBook
{
    public class AddressBook
    {
        public static bool flag;
        List<Contact> contactList = new List<Contact>();
        public void AddContact()
        {
            flag = true;
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
                if (flag)
                {
                    contactList.Add(contact);
                    Console.WriteLine("Contact added..");  
                }
                else
                {
                    Console.WriteLine("Contact not added..");
                }
            }
            else
            {
                throw new DuplicateContactFoundException("Duplicate Contacts... PLease Change name of the contact");
            }
        }

        public void AdddToJSONFile()
        {
            string path = "C:\\Users\\prajw\\source\\repos\\ExceptionHandlingAddresssBook\\ExceptionHandlingAddresssBook\\TestJSON.txt";
            string jsonContent = JsonConvert.SerializeObject(contactList);  
            File.WriteAllText(path,jsonContent);

        }

        public void ReadFronJSONFile()
        {
            List<Contact> JSONFileList = new List<Contact>();

            string path = "C:\\Users\\prajw\\source\\repos\\ExceptionHandlingAddresssBook\\ExceptionHandlingAddresssBook\\TestJSON.txt";
            string fileContent = File.ReadAllText(path);
            JSONFileList = JsonConvert.DeserializeObject<List<Contact>>(fileContent);
            foreach (var contact in JSONFileList)
            {
                Console.WriteLine(contact);
            }
        }
        public void AddToCSVFile()
        {
            string path = "C:\\Users\\prajw\\source\\repos\\ExceptionHandlingAddresssBook\\ExceptionHandlingAddresssBook\\Test.txt";
            StreamWriter Writer = new StreamWriter(path,true);
            CsvWriter CSVwriter = new CsvWriter(Writer, CultureInfo.InvariantCulture);
            CSVwriter.WriteRecords(contactList);
            CSVwriter.Dispose();
            Writer.Close(); 
        }
        public void ReadFromCSVFile()
         {
             List<Contact> CSVFileList = new List<Contact>();
             string path = "C:\\Users\\prajw\\source\\repos\\ExceptionHandlingAddresssBook\\ExceptionHandlingAddresssBook\\Test.txt";

             StreamReader reader = new StreamReader(path);
             CsvReader csvReader = new CsvReader(reader,CultureInfo.InvariantCulture);

             CSVFileList = csvReader.GetRecords<Contact>().ToList();
             foreach (Contact contact in CSVFileList)
             {
                 Console.WriteLine(contact);
                Console.WriteLine();
            }

             reader.Close();
             csvReader.Dispose();
         }

        public void Display()
        {
            int cout = 0;
            foreach (Contact contact in contactList)
            {
                Console.WriteLine(contact);
                cout++;
            }
            if (cout == 0)
            {
                Console.WriteLine("List is empty");
            }

        }

        public void Delete()
        {
            bool found = false;
            Console.WriteLine("Enter name of the contact: ");
            string input = Console.ReadLine();
            for (int i = 0; i < contactList.Count; i++)
            {
                Contact contact = contactList[i];
                if (input == contact.Name)
                {
                    found = true;
                    contactList.Remove(contact);
                    Console.WriteLine("Contact deleted ....");
                    return;
                }
            }
            if (!found) 
            {
                    throw new ContactNotFoundException("Contact not found........");
            }
            //Console.WriteLine($"{input} not found in addressBook");
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
