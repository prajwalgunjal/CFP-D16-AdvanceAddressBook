using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExceptionHandlingAddresssBook
{
    public class AddressBook
    {
        public static bool flag;
        List<Contact> contactList = new List<Contact>();

        string path = "C:\\Users\\prajw\\source\\repos\\ExceptionHandlingAddresssBook\\ExceptionHandlingAddresssBook\\TestJSON.json";


        public AddressBook() {
            contactList = LoadContactsFromFile();
                }
        public bool AddContact()
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
                    return true;
                }
                else
                {
                   return false;
                }
            }
            else
            {
                throw new DuplicateContactFoundException("Duplicate Contacts... PLease Change name of the contact");
            }
        }

        public void AdddToJSONFile()
        {
            string path = "C:\\Users\\prajw\\source\\repos\\ExceptionHandlingAddresssBook\\ExceptionHandlingAddresssBook\\TestJSON.json";
            string jsonContent = JsonConvert.SerializeObject(contactList);  
            File.WriteAllText(path,jsonContent);

        }

        public bool ReadFronJSONFile()
        {
            List<Contact> JSONFileList = new List<Contact>();

            try
            {
                string fileContent = File.ReadAllText(path);
                JSONFileList = JsonConvert.DeserializeObject<List<Contact>>(fileContent);
                foreach (var contact in JSONFileList)
                {
                    Console.WriteLine(contact);
                }
                return true;
            }
            catch (Exception ex) { 
            return false;
            }
        }
        public void AddToCSVFile()
        {
            string path = "C:\\Users\\prajw\\source\\repos\\ExceptionHandlingAddresssBook\\ExceptionHandlingAddresssBook\\Test.csv";
            StreamWriter Writer = new StreamWriter(path,true);
            CsvWriter CSVwriter = new CsvWriter(Writer, CultureInfo.InvariantCulture);
            CSVwriter.WriteRecords(contactList);
            CSVwriter.Dispose();
            Writer.Close(); 
        }
        public bool ReadFromCSVFile()
         {
             List<Contact> CSVFileList = new List<Contact>();
             string path = "C:\\Users\\prajw\\source\\repos\\ExceptionHandlingAddresssBook\\ExceptionHandlingAddresssBook\\Test.csv";
            try
            {
                StreamReader reader = new StreamReader(path);
                CsvReader csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);

                CSVFileList = csvReader.GetRecords<Contact>().ToList();
                foreach (Contact contact in CSVFileList)
                {
                    Console.WriteLine(contact);
                    Console.WriteLine();
                }
                reader.Close();
                csvReader.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
         }

        public bool Display()
        {
            contactList = LoadContactsFromFile();
            foreach (Contact contact in contactList)
            {
                Console.WriteLine(contact);
                return true;
            }
            
            return false;
        }
        public bool Delete()
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
                    return true;
                }
            }
            if (!found) 
            {
                    throw new ContactNotFoundException("Contact not found........");
            }
            return false;
        }
        /*public bool ReadJson(string name, string email, string phone, string state, string city, string zip)
        {
            Edit();

            List<Contact> JSONFileList = new List<Contact>();

            try
            {
                string fileContent = File.ReadAllText(path);
                JSONFileList = JsonConvert.DeserializeObject<List<Contact>>(fileContent);
                foreach (var contact in JSONFileList)
                {
                    if (contact.Name == name)
                    {
                        contact.Name = name;
                        contact.Email = email;
                        contact.Phone = phone;
                        contact.State = state;
                        contact.City = city;
                        contact.Zipcode = zip;
                        break;
                    }
                }
                AdddToJSONFile();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }*/
        public bool Edit()
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

                    AdddToJSONFile();
                  // ReadJson(name,email,phone,state,city,zip);
                    return true;

                }
            }
            return false;
        }

        public void SaveContactsToFile()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            string json = JsonConvert.SerializeObject(contactList, settings);
            File.WriteAllText(path, json);
        }

        private List<Contact> LoadContactsFromFile()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
                return contacts ?? new List<Contact>();
            }

            return new List<Contact>();
        }
    }
}
