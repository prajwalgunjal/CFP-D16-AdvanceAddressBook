﻿using System.Text.RegularExpressions;
namespace ExceptionHandlingAddresssBook
{
    public class Program
    {
        public bool TestFirstName(string name)
        {
            Regex Checkname = new Regex("^[A-Z][a-z]{2,}");
            Match match = Checkname.Match(name);
            if (match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TestEmail(string email)
        {
            Regex CheckEmail = new Regex("^\\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Za-z]{2,}\\b");

            if (CheckEmail.IsMatch(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool TestPhoneNumber(string phno)
        {
            Regex Phone = new Regex("^(\\+?\\d{1,3})\\s\\d{10}$");

            if (Phone.IsMatch(phno))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("welcome to AddressBook : ");
            while (true)
            {
                Console.WriteLine("Choose your operation:");
                Console.WriteLine("1) Add contact");
                Console.WriteLine("2) Display Contact");
                Console.WriteLine("3) Delete Contact");
                Console.WriteLine("4) Edit Contact");
                Console.WriteLine("5) Read From CSV");
                Console.WriteLine("6) Read From JSON");
                Console.WriteLine("9) Exit");
                string choiceString = Console.ReadLine();
                int choice;

                if (int.TryParse(choiceString, out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            {
                                try
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

                                    if (addressBook.AddContact(name,email,phone,city,state,zip))
                                    {
                                        Console.WriteLine("Contact Added Successfully");
                                    }
                                }
                                catch(Exception somename)
                                {
                                    Console.WriteLine(somename.Message);
                                }
                                break;

                            }
                        case 2:
                            {
                                try
                                {
                                   if(addressBook.Display())
                                    {
                                        Console.WriteLine("contact displyed");
                                    }
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("************EXCEPTION***********");
                                }
                                break;
                            }
                        case 3:
                            {
                                if (addressBook.Delete())
                                {
                                    Console.WriteLine("Contact deleted ...");
                                }
                                break;
                            }
                        case 4:
                            { 
                                if (addressBook.Edit())
                                {
                                    Console.WriteLine("Contact Editied Successfully");
                                }
                                else
                                {
                                    Console.WriteLine("Contact is not editied");
                                }
                                break;
                            }

                    case 5:
                            {
                                if (!addressBook.ReadFromCSVFile())
                                {
                                    Console.WriteLine("Something Error");
                                }
                                break;
                            }
                        case 6:
                            {
                                if (!addressBook.ReadFronJSONFile())
                                {
                                    Console.WriteLine("Something Error");
                                }
                                break;
                            }
                        case 9:
                            {
                                addressBook.AddToCSVFile();
                                addressBook.AdddToJSONFile();
                                Environment.Exit(0);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invalid choice.");
                                break;
                            }

                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a valid integer choice.");
                }

            }
        }
    }
}