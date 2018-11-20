using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Simr.Common.Enums;

namespace Simr.DataLayer.DbEntities
{
    public class DbUser 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public bool IsSynchronized { get; set; }

        public string Email { get; set; }

        public Language Language { get; set; }

        public UserRoles Roles { get; set; }

        public string Username { get; set; }
    }
}