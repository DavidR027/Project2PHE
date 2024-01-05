using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Project2PHE.Models
{
    public class Employee
    {
        public Employee()
        {
            Vendors = new HashSet<Vendor>();
        }

        [Key]
        public string Guid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Vendor> Vendors { get; set; }
        public virtual Account AccountNavigation { get; set; }
    }
}