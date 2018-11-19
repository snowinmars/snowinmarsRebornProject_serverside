using System;

namespace Simr.Entities
{
    public class Author : Entity
    {
        public Author(string aka)
        {
            if (string.IsNullOrWhiteSpace(aka))
            {
                throw new ArgumentException("Shortcut can't be empty");
            }

            Aka = aka;

            Pseudonym = new PersonName();
            Name = new PersonName();
        }

        public DateTime BirthDate { get; set; }

        public DateTime? DeathDate { get; set; }

        public string PhotoUrl { get; set; }

        public string Info { get; set; }

        public PersonName Name { get; set; }

        public PersonName Pseudonym { get; set; }

        public string Aka { get; }
    }
}