using System;

namespace Sibr.Entities
{
    public class Author : Entity
    {
        public Author(string aka)
        {
            if (string.IsNullOrWhiteSpace(aka))
            {
                throw new ArgumentException("Shortcut can't be empty");
            }

            this.Aka = aka;

            this.Pseudonym = new PersonName();
            this.Name = new PersonName();
        }

        public PersonName Name { get; set; }
        public PersonName Pseudonym { get; set; }
        public string Aka { get; }
    }
}
