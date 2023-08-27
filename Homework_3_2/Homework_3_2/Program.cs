using System;
using System.Globalization;
using System.Text;

namespace Homework_3_2
{
    /// <summary>
    /// Main class.
    /// </summary>
    internal sealed class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        /// <param name="args">Args.</param>
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ContactCollection contacts = new ContactCollection();
            contacts.AddContact(new Contact("0983156712", "Іван"), new CultureInfo("en-US"));
            contacts.AddContact(new Contact("0949049876", "Ivan"));
            contacts.AddContact(new Contact("0689873428", "Nick"), new CultureInfo("uk-UA"));
            contacts.AddContact(new Contact("0689873428", "Ann"), new CultureInfo("uk-UA"));
            contacts.AddContact(new Contact("0983156712", "Andrew"), new CultureInfo("en-US"));
            contacts.AddContact(new Contact("0949049876", "029Kiril"));
            contacts.AddContact(new Contact("0689873428", "Олексій"), new CultureInfo("uk-UA"));
            contacts.AddContact(new Contact("0689873428", "Вікторія"), new CultureInfo("uk-UA"));

            foreach (var contact in contacts.SortedContacts)
            {
                Console.WriteLine(contact.Key);
                foreach (var c in contact.Value)
                {
                    Console.WriteLine($"{c}");
                }

                Console.WriteLine();
            }
        }
    }
}