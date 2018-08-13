using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibr.Entities
{
    using Sirb.Common;

    public class Author : Entity
    {
        public Author(string aka)
        {
            if (string.IsNullOrWhiteSpace(aka))
            {
                throw new ArgumentException("Shortcut can't be empty");
            }

            this.Aka = aka;

            this.Pseudonym = new Pseudonym();
        }

        public string FamilyName { get; set; }
        public string FullMiddleName { get; set; }
        public string GivenName { get; set; }
        public Pseudonym Pseudonym { get; set; }
        public string Aka { get; set; }
    }
}
