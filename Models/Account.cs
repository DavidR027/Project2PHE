using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2PHE.Models
{
    public class Account
    {
        [Key]
        public string Guid { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }

        public virtual Vendor VendorNavigation { get; set; }
        public virtual Employee EmployeeNavigation { get; set; }
    }
}