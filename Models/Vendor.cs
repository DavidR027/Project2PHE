using System;
using System.ComponentModel.DataAnnotations;

namespace Project2PHE.Models
{
    public class Vendor
    {
        [Key]
        public string Guid { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string CompanyEmail { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsApproved { get; set; }
        public string ApprovedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string BusinessField { get; set; }
        public string BusinessType { get; set; }

        public virtual Employee EmployeeNavigation { get; set; }
        public virtual Account AccountNavigation { get; set; }
    }
}