namespace ExceptionHandlingAddresssBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddressBook addressBook = new AddressBook();
            Console.WriteLine("welcome to AddressBook : ");
            while (true)
            {
                Console.WriteLine("Choose your operation: ");
                Console.WriteLine("1) Add contact");
                Console.WriteLine("2) Display Contact");
                Console.WriteLine("3) Delete Contact");
                Console.WriteLine("4) Edit Contact");
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
                                    addressBook.addContact();
                                }
                                catch(Exception)
                                {
                                    Console.WriteLine("**********EXCEPTION***********");
                                }
                                break;

                            }
                        case 2:
                            {
                                try
                                {
                                    addressBook.Display();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("************EXCEPTION***********");
                                }
                                break;
                            }
                        case 3:
                            {
                                addressBook.delete();
                                break;
                            }
                        case 4:
                            {
                                addressBook.Edit();
                                break;
                            }
                        case 9:
                            {
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