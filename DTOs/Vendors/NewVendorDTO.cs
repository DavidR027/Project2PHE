using Project2PHE.Models;
using System;

namespace Project2PHE.DTOs.Vendors
{
    public class NewVendorDTO
    {
        public string CompanyName { get; set; } = null;
        public string Address { get; set; }
        public string CompanyEmail { get; set; }
        public string Phone { get; set; }
        public byte[] Photo { get; set; }
        public DateTime CreateDate { get; set; }
        public string ApprovedBy { get; set; }
        public string BusinessField { get; set; }
        public string BusinessType { get; set; }

        public static implicit operator Vendor(NewVendorDTO vendorDTO)
        {
            return new Vendor
            {
                CompanyName = vendorDTO.CompanyName,
                Address = vendorDTO.Address,
                CompanyEmail = vendorDTO.CompanyEmail,
                Phone = vendorDTO.Phone,
                Photo = vendorDTO.Photo,
                CreateDate = vendorDTO.CreateDate,
                ApprovedBy = vendorDTO.ApprovedBy,
                BusinessField = vendorDTO.BusinessField,
                BusinessType = vendorDTO.BusinessType,
            };
        }

        public static explicit operator NewVendorDTO(Vendor vendor)
        {
            return new NewVendorDTO
            {
                CompanyName = vendor.CompanyName,
                Address = vendor.Address,
                CompanyEmail = vendor.CompanyEmail,
                Phone = vendor.Phone,
                Photo = vendor.Photo,
                CreateDate = vendor.CreateDate,
                ApprovedBy = vendor.ApprovedBy,
                BusinessField = vendor.BusinessField,
                BusinessType = vendor.BusinessType,
            };
        }
    }
}
