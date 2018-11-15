using System;

namespace Simr.DataLayer.DbEntities
{
    public class DbAuthor 
    {
        public DbAuthor()
        {
        }

        public Guid Id { get; set; }

        public bool IsSynchronized { get; set; }

        public string FamilyName { get; set; }

        public string FullMiddleName { get; set; }

        public string GivenName { get; set; }

        public string PseudonymFamilyName { get; set; }

        public string PseudonymFullMiddleName { get; set; }

        public string PseudonymGivenName { get; set; }

        public string Aka { get; set; }
    }
}