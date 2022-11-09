using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TransportManagement.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            Employees = new HashSet<Employee>();
            Routes = new HashSet<Route>();
        }

        public int VehicleId { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]{2}[-][0-9]{1,2}[-][A-Z]{1,2}[-][0-9]{3,4}$", ErrorMessage = "Please Enter A Valid Vehicle Number")]
        public string VehicleNo { get; set; } = null!;
        [Required]
        public int Capacity { get; set; }
        [Required]
        public int AvailableSeats { get; set; }
        [Required]
        public string Operable { get; set; } = null!;

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Route> Routes { get; set; }
    }
}
