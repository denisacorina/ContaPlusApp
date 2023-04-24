﻿using System.ComponentModel.DataAnnotations;

namespace ContaPlusAPI.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<User>? Users { get; set; } = new List<User>();
    }
}
