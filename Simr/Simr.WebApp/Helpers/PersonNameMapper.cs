namespace Simr.WebApp.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    using Sibr.Entities;

    using Simr.WebApp.Models.PersonName;

    internal static class PersonNameMapper
    {
        public static IEnumerable<PersonNameModel> ToPersonNameModels(this PersonName[] personNames)
        {
            return personNames.Select(PersonNameMapper.ToPersonNameModel);
        }

        public static IEnumerable<PersonName> ToPersonNames(this PersonNameModel[] personNameModels)
        {
            return personNameModels.Select(PersonNameMapper.ToPersonName);
        }

        public static PersonNameModel ToPersonNameModel(this PersonName personName)
        {
            return new PersonNameModel
                       {
                           GivenName = personName.GivenName,
                           FullMiddleName = personName.FullMiddleName,
                           FamilyName = personName.FamilyName,
                           Id = personName.Id,
                       };
        }

        public static PersonName ToPersonName(this PersonNameModel personNameModel)
        {
            return new PersonName
                       {
                           GivenName = personNameModel.GivenName,
                           FullMiddleName = personNameModel.FullMiddleName,
                           FamilyName = personNameModel.FamilyName,
                           Id = personNameModel.Id,
                       };
        }
    }
}