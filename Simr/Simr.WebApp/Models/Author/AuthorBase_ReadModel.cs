using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simr.WebApp.Models.Author
{
    using Simr.WebApp.Models.Pseudonym;

    public class AuthorBase_ReadModel
    {
        public string FamilyName { get; set; }
        public string FullMiddleName { get; set; }
        public string GivenName { get; set; }
        public PseudonymBase_ReadModel Pseudonym { get; set; }
        public string Aka { get; set; }
    }
}