using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TransportManagement.Models
{
    public partial class Route
    {
        [Required]
        [RegularExpression(@"^[A-Z]{2}[-][0-9]{1,2}[-][A-Z]{1,2}[-][0-9]{3,4}$", ErrorMessage = "Please Enter a Valid Route Number")]
        public int RoutetId { get; set; }
        [Required]
        public string RouteNo { get; set; } = null!;
        [Required]
        [Display(Name = "From")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets are Allowed")]

        public string Stop1 { get; set; } = null!;
        [Required]
        [Display(Name = "To")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets are Allowed")]

        public string Stop2 { get; set; } = null!;
        public int? VehicleNo { get; set; }

        public virtual Vehicle? VehicleNoNavigation { get; set; }
    }
}
