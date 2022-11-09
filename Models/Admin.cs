using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportManagement.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Password { get; set; } = null!;
    }
}
