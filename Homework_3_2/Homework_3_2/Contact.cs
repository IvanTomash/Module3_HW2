using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_3_2
{
    /// <summary>
    /// Represents phone contacts.
    /// </summary>
    internal sealed class Contact : IComparable<Contact>
    {
        private string name;

        private string number;

        /// <summary>
        /// Initializes a new instance of the <see cref="Contact"/> class.
        /// </summary>
        /// <param name="number">Accepted phone number.</param>
        /// <param name="name">Accepted name.</param>
        public Contact(string number, string name = "")
        {
            this.name = name;
            this.number = number;
        }

        /// <summary>
        /// Gets a name.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string res = $"{this.name} {this.number}";
            return res;
        }

        /// <inheritdoc/>
        public int CompareTo(Contact other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
