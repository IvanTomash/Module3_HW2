using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Homework_3_2
{
    /// <summary>
    /// Stores contacts in a sorted dictionary.
    /// </summary>
    internal sealed class ContactCollection
    {
        private readonly Dictionary<CultureInfo, List<Contact>> contactsDictionary;
        private readonly SortedDictionary<string, List<Contact>> sortedContacts;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactCollection"/> class.
        /// </summary>
        public ContactCollection()
        {
            this.contactsDictionary = new Dictionary<CultureInfo, List<Contact>>();
            this.sortedContacts = new SortedDictionary<string, List<Contact>>();
        }

        /// <summary>
        /// Gets sortedContacts value.
        /// </summary>
        public SortedDictionary<string, List<Contact>> SortedContacts
        {
            get { return this.sortedContacts; }
        }

        /// <summary>
        /// Adds a contact to contactsDictionary.
        /// </summary>
        /// <param name="newContact">New contact.</param>
        /// <param name="cultureInfo">Determine culture info for the new contact.</param>
        public void AddContact(Contact newContact, CultureInfo cultureInfo = null)
        {
            if (cultureInfo == null)
            {
                cultureInfo = CultureInfo.GetCultureInfo("en-US");
            }

            if (!this.contactsDictionary.ContainsKey(cultureInfo))
            {
                this.contactsDictionary.Add(cultureInfo, new List<Contact>());
            }

            this.contactsDictionary[cultureInfo].Add(newContact);

            this.AddToSortedContacts(newContact, cultureInfo);
        }

        private void AddToSortedContacts(Contact newContact, CultureInfo cultureInfo)
        {
            if (!this.sortedContacts.ContainsKey(cultureInfo.DisplayName))
            {
                this.sortedContacts.Add(cultureInfo.DisplayName, new List<Contact>());
            }

            if (this.CheckCharactersForLetters(newContact.Name, cultureInfo))
            {
                this.sortedContacts[cultureInfo.DisplayName].Add(newContact);
            }
            else if (this.CheckCharactersForNumbers(newContact.Name))
            {
                if (!this.sortedContacts.ContainsKey("0-9"))
                {
                    this.sortedContacts.Add("0-9", new List<Contact>());
                }

                this.sortedContacts["0-9"].Add(newContact);
            }
            else
            {
                if (!this.sortedContacts.ContainsKey("#"))
                {
                    this.sortedContacts.Add("#", new List<Contact>());
                }

                this.sortedContacts["#"].Add(newContact);
            }

            this.sortedContacts[cultureInfo.DisplayName].Sort();
        }

        /// <summary>
        /// Gets alphabet depending on cultureInfo.
        /// </summary>
        /// <param name="cultureInfo">Accepted culture.</param>
        /// <returns>Appropriate alphabet.</returns>
        private string GetAlphabet(CultureInfo cultureInfo)
        {
            switch (cultureInfo.Name)
            {
                case "en-US":
                    return "abcdefghijklmnopqrstuvwxyz";
                case "uk-UA":
                    return "абвгдеєжзиіїйклмнопрстуфхцчшщьюя";
                default:
                    return "abcdefghijklmnopqrstuvwxyz";
            }
        }

        /// <summary>
        /// Check if all letters of the name correspond a certain alphabet.
        /// </summary>
        /// <param name="name">Accepted name.</param>
        /// <param name="cultureInfo">Culture info is used for assigning an alphabet.</param>
        /// <returns>True - if all letters of the name correspond a certain alphabet. </returns>
        private bool CheckCharactersForLetters(string name, CultureInfo cultureInfo)
        {
            string alphabet = this.GetAlphabet(cultureInfo);
            string lowerName = name.ToLower();
            int marker = 0;
            for (int i = 0; i < name.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (!(lowerName[i] == alphabet[j]))
                    {
                        marker++;
                    }
                }

                if (marker == alphabet.Length)
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Check if the first letter of the name is a number.
        /// </summary>
        /// <param name="name">Accepted name.</param>
        /// <returns>True - he first letter of the name is a number.</returns>
        private bool CheckCharactersForNumbers(string name)
        {
            if (char.IsDigit(name[0]))
            {
                return true;
            }

            return false;
        }
    }
}
