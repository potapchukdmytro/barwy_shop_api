﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace DAL.Entities.Identity
{
    public sealed class UserEntity : IdentityUser
    {
        [StringLength(255)]
        public string FirstName { get; set; }
        [StringLength(255)]
        public string LastName { get; set; }
        [StringLength(255)]
        public string Image { get; set; }
        public ICollection<UserRoleEntity> UserRoles { get; set; }
    }
}
