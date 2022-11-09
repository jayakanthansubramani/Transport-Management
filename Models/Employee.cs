using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportManagement.Models
{
    public partial class Employee
    {
    
        public int EmployeeId { get; set; }
        [Required]
        [Display(Name = "Employee Name")]
        [DataType(DataType.Text)]

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets are Allowed")]
        public string EmployeeName { get; set; } = null!;

        [Required(ErrorMessage = "Age is Required")]
        [Range(1, 120, ErrorMessage = "Age must be between 1-120 in years.")]
        public int Age { get; set; }
        [Required]
        [Display(Name = "Location")]
        [DataType(DataType.Text)]

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets are Allowed")]
        public string Location { get; set; } = null!;
        [Required]
        //[DataType(DataType.PhoneNumber)]
        //[StringLength(13, MinimumLength = 10)]
        public string Phone { get; set; } = null!;
        public int? VehicleId { get; set; }

        public virtual Vehicle? Vehicle { get; set; }
    }
}
