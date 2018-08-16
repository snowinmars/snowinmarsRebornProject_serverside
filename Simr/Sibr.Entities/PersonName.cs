using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibr.Entities
{
    public class PersonName : Entity
    {
        public PersonName()
        {
            GivenName = string.Empty;
            FullMiddleName = string.Empty;
            FamilyName = string.Empty;
        }

        public string FamilyName { get; set; }
        public string FullMiddleName { get; set; }
        public string GivenName { get; set; }
    }
}
