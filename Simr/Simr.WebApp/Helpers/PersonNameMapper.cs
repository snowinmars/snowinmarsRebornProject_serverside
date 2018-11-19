using System.Collections.Generic;
using System.Linq;

using Simr.Entities;
using Simr.WebApp.Models.Author.Read;

namespace Simr.WebApp.Helpers
{
    internal static class PersonNameMapper
    {
        public static IEnumerable<PersonNameModel> ToPersonNameModels(this PersonName[] personNames)
        {
            return personNames.Select(ToPersonNameModel);
        }

        public static IEnumerable<PersonName> ToPersonNames(this PersonNameModel[] personNameModels)
        {
            return personNameModels.Select(ToPersonName);
        }

        public static PersonNameModel ToPersonNameModel(this PersonName personName)
        {
            return new PersonNameModel
            {
                GivenName = personName.GivenName,
                FullMiddleName = personName.FullMiddleName,
                FamilyName = personName.FamilyName,
            };
        }

        public static PersonName ToPersonName(this PersonNameModel personNameModel)
        {
            return new PersonName
            {
                GivenName = personNameModel.GivenName,
                FullMiddleName = personNameModel.FullMiddleName,
                FamilyName = personNameModel.FamilyName,
            };
        }
    }
}