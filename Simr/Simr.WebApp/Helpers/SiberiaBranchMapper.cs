using Simr.Entities;
using Simr.WebApp.Models.Siberia.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simr.WebApp.Helpers
{
    public static class SiberiaBranchMapper
    {
        public static IEnumerable<SiberiaBranch> ToSiberiaBranches(this SiberiaBranchGridModel[] siberiaBranchesGridModel)
        {
            return siberiaBranchesGridModel.Select(ToSiberiaBranch);
        }

        public static IEnumerable<SiberiaBranchGridModel> ToSiberiaBranchesGridModels(this SiberiaBranch[] siberiaBranchesGridModel)
        {
            return siberiaBranchesGridModel.Select(ToSiberiaBranchGridModels);
        }

        public static SiberiaBranchGridModel ToSiberiaBranchGridModels(this SiberiaBranch siberiaBranchesGridModel)
        {
            return new SiberiaBranchGridModel
            {
                Emviroment = siberiaBranchesGridModel.Enviroment,
                Name = siberiaBranchesGridModel.Name,
                Id = siberiaBranchesGridModel.Id,
            };
        }

        public static SiberiaBranch ToSiberiaBranch(this SiberiaBranchGridModel siberiaBranchesGridModel)
        {
            return new SiberiaBranch
            {
                Enviroment = siberiaBranchesGridModel.Emviroment,
                Name = siberiaBranchesGridModel.Name,
                Id = siberiaBranchesGridModel.Id,
            };
        }
    }
}