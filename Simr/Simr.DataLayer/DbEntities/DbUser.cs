using System;
using System.ComponentModel.DataAnnotations;

using Simr.Common.Enums;

namespace Simr.DataLayer.DbEntities
{
    public class DbUser 
    {
        public DbUser(string username)
        {
            Username = username;
        }

        [Key]
        public Guid Id { get; set; }

        public bool IsSynchronized { get; set; }

        public string Email { get; set; }

        public Language Language { get; set; }

        public UserRoles Roles { get; set; }

        public string Username { get; set; }
    }
}