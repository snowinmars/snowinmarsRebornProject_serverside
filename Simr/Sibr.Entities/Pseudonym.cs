using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sibr.Entities
{
    public class Pseudonym : Entity
    {
        public Pseudonym()
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
