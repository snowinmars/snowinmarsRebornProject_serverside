using Simr.Entities;
using Simr.WebApp.Models.Siberia.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Simr.WebApp.Helpers
{
    public static class SiberiaEnvironmentMapper
    {
        public static IEnumerable<SiberiaEnvironment> ToSiberiaBranches(this SiberiaEnvironmentGridModel[] siberiaBranchGridModels)
        {
            return siberiaBranchGridModels.Select(ToSiberiaEnvironment);
        }

        public static IEnumerable<SiberiaEnvironmentGridModel> ToSiberiaBranchesGridModels(this SiberiaEnvironment[] siberiaBranchGridModels)
        {
            return siberiaBranchGridModels.Select(ToSiberiaEnvironmentGridModels);
        }

        public static SiberiaEnvironmentGridModel ToSiberiaEnvironmentGridModels(this SiberiaEnvironment siberiaEnvironmentGridModel)
        {
            return new SiberiaEnvironmentGridModel
            {
                Environment = siberiaEnvironmentGridModel.Environment,
                Name = siberiaEnvironmentGridModel.Name,
                Id = siberiaEnvironmentGridModel.Id,
            };
        }

        public static SiberiaEnvironment ToSiberiaEnvironment(this SiberiaEnvironmentGridModel siberiaEnvironmentGridModel)
        {
            return new SiberiaEnvironment
            {
                Environment = siberiaEnvironmentGridModel.Environment,
                Name = siberiaEnvironmentGridModel.Name,
                Id = siberiaEnvironmentGridModel.Id,
            };
        }
    }
}