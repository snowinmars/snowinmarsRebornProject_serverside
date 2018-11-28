using Simr.Entities;
using Simr.WebApp.Models.Siberia.Read;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Simr.WebApp.Models.Siberia.Write;

namespace Simr.WebApp.Helpers
{
    public static class SiberiaEnvironmentMapper
    {
        public static IEnumerable<SiberiaEnvironment> ToSiberiaEnvironments(this SiberiaEnvironmentGridModel[] siberiaBranchGridModels)
        {
            return siberiaBranchGridModels.Select(ToSiberiaEnvironment);
        }

        public static IEnumerable<SiberiaEnvironment> ToSiberiaEnvironments(this SiberiaEnvironmentWriteModel[] siberiaEnvironmentCreateModel)
        {
            return siberiaEnvironmentCreateModel.Select(ToSiberiaEnvironment);
        }

        public static IEnumerable<SiberiaEnvironmentGridModel> ToSiberiaEnvironmentCreateModels(this SiberiaEnvironment[] siberiaBranchGridModels)
        {
            return siberiaBranchGridModels.Select(ToSiberiaEnvironmentGridModels);
        }

        public static IEnumerable<SiberiaEnvironmentWriteModel> SiberiaEnvironmentWriteModels(this SiberiaEnvironment[] siberiaEnvironmentCreateModels)
        {
            return siberiaEnvironmentCreateModels.Select(ToSiberiaEnvironmentCreateModel);
        }

        public static SiberiaEnvironmentWriteModel ToSiberiaEnvironmentCreateModel(this SiberiaEnvironment siberiaEnvironmentCreateModel)
        {
            return new SiberiaEnvironmentWriteModel
            {
                Branch = siberiaEnvironmentCreateModel.Branch,
                Environment = siberiaEnvironmentCreateModel.Environment,
                Id = siberiaEnvironmentCreateModel.Id,
            };
        }

        public static SiberiaEnvironmentGridModel ToSiberiaEnvironmentGridModels(this SiberiaEnvironment siberiaEnvironmentGridModel)
        {
            return new SiberiaEnvironmentGridModel
            {
                Branch = siberiaEnvironmentGridModel.Branch,
                Environment = siberiaEnvironmentGridModel.Environment,
                Id = siberiaEnvironmentGridModel.Id,
            };
        }

        public static SiberiaEnvironment ToSiberiaEnvironment(this SiberiaEnvironmentGridModel siberiaEnvironmentGridModel)
        {
            return new SiberiaEnvironment
            {
                Branch = siberiaEnvironmentGridModel.Branch,
                Environment = siberiaEnvironmentGridModel.Environment,
                Id = siberiaEnvironmentGridModel.Id,
            };
        }

        public static SiberiaEnvironment ToSiberiaEnvironment(this SiberiaEnvironmentWriteModel siberiaEnvironmentCreateModel)
        {
            return new SiberiaEnvironment
            {
                Branch = siberiaEnvironmentCreateModel.Branch,
                Environment = siberiaEnvironmentCreateModel.Environment,
                Id = siberiaEnvironmentCreateModel.Id,
            };
        }
    }
}