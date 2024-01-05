using Project2PHE.Contracts;
using Project2PHE.DTOs.Vendors;
using Project2PHE.Models;
using Project2PHE.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.Entity;
using Project2PHE.Contexts;

namespace Project2PHE.Services
{
    public class VendorServices
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly RegisterDbContext _registerDbContext;

        public VendorServices(IVendorRepository vendorRepository, IAccountRepository accountRepository, RegisterDbContext registerDbContext)
        {
            _vendorRepository = vendorRepository;
            _accountRepository = accountRepository;
            _registerDbContext = registerDbContext;
        }

        public IEnumerable<VendorDTO> GetAllVendor()
        {
            var vendors = _vendorRepository.GetAll();

            if (!vendors.Any()) return Enumerable.Empty<VendorDTO>();

            var getVendors = new List<VendorDTO>();

            foreach (var vendor in vendors)
            {

                getVendors.Add(new VendorDTO
                {
                    Guid = vendor.Guid,
                    CompanyName = vendor.CompanyName,
                    Address = vendor.Address,
                    CompanyEmail = vendor.CompanyEmail,
                    Phone = vendor.Phone,
                    Photo = vendor.Photo,
                    CreateDate = vendor.CreateDate,
                    IsApproved = vendor.IsApproved,
                    ApprovedBy = vendor.ApprovedBy,
                    BusinessField = vendor.BusinessField,
                    BusinessType = vendor.BusinessType,
                    IsDeleted = vendor.IsDeleted,
                });
            }

            return getVendors;
        }

        public NewVendorDTO CreateVendor(NewVendorDTO vendorDto)
        {
            var vendor = new Vendor
            {
                Guid = Guid.NewGuid().ToString(),
                CompanyName = vendorDto.CompanyName,
                Address = vendorDto.Address,
                CompanyEmail = vendorDto.CompanyEmail,
                Phone = vendorDto.Phone,
                Photo = vendorDto.Photo,
                CreateDate = DateTime.Now,
                IsApproved = false,
                ApprovedBy = vendorDto.ApprovedBy,
                IsDeleted = false,
                BusinessField = vendorDto.BusinessField,
                BusinessType = vendorDto.BusinessType,
            };

            _vendorRepository.Create(vendor);
            return vendorDto;
        }

        public VendorDTO GetVendorByGuid(string guid)
        {
            var vendor = _vendorRepository.GetByGuid(guid);
            if (vendor == null || vendor.IsDeleted) return null;

            // Map the vendor to a VendorDTO
            var vendorDto = new VendorDTO
            {
                Guid = vendor.Guid,
                CompanyName = vendor.CompanyName,
                Address = vendor.Address,
                CompanyEmail = vendor.CompanyEmail,
                Phone = vendor.Phone,
                Photo = vendor.Photo,
                CreateDate = vendor.CreateDate,
                IsApproved = vendor.IsApproved,
                ApprovedBy = vendor.ApprovedBy,
                BusinessField = vendor.BusinessField,
                BusinessType = vendor.BusinessType,
                IsDeleted = vendor.IsDeleted
            };

            return vendorDto;
        }

        public VendorDTO UpdateVendor(VendorDTO vendorDto)
        {
            var vendor = _vendorRepository.GetByGuid(vendorDto.Guid);
            if (vendor == null || vendor.IsDeleted) return null;

            //Update
            vendor.Guid = vendorDto.Guid;
            vendor.CompanyName = vendorDto.CompanyName;
            vendor.Address = vendorDto.Address;
            vendor.CompanyEmail = vendorDto.CompanyEmail;
            vendor.Phone = vendorDto.Phone;
            vendor.Photo = vendorDto.Photo;
            vendor.CreateDate = vendorDto.CreateDate;
            vendor.IsApproved = vendorDto.IsApproved;
            vendor.ApprovedBy = vendorDto.ApprovedBy;
            vendor.BusinessField = vendorDto.BusinessField;
            vendor.BusinessType = vendorDto.BusinessType;

            _vendorRepository.Update(vendor);
            return vendorDto;
        }

        public bool DeleteVendor(string guid)
        {
            var vendor = _vendorRepository.GetByGuid(guid);
            if (vendor == null || vendor.IsDeleted) throw new Exception("Vendor not found");

            vendor.IsDeleted = true;
            return _vendorRepository.Update(vendor);
        }

        public RegisterDTO RegisterVendor(RegisterDTO registerDto)
        {
            var guid = Guid.NewGuid().ToString();

            //Placeholder for ApprovedBy
            var approvedBy = "EE7C89C6-0C65-44A2-AF87-1815769FC983";

            var vendor = new Vendor
            {
                Guid = guid,
                CompanyName = registerDto.CompanyName,
                Address = registerDto.Address,
                CompanyEmail = registerDto.CompanyEmail,
                Phone = registerDto.Phone,
                Photo = registerDto.Photo,
                CreateDate = DateTime.Now,
                IsApproved = false,
                ApprovedBy = approvedBy,
                IsDeleted = false,
                BusinessField = null,
                BusinessType = null,
            };
            _vendorRepository.Create(vendor);

            var account = new Account
            {
                Guid = guid,
                Role = "Vendor",
                Password = registerDto.Password,
            };
            _accountRepository.Create(account);

            _registerDbContext.SaveChanges();

            return registerDto;
        }

        public bool ApproveVendor(string guid)
        {
            var vendor = _vendorRepository.GetByGuid(guid);
            if (vendor == null) return false;

            vendor.IsApproved = true;
            //Temporary solution
            vendor.ApprovedBy = "50ABF556-1E3E-4B6B-935E-5A0B0E006B56";
            _vendorRepository.Update(vendor);

            return true;
        }

        public bool RejectVendor(string guid)
        {
            var vendor = _vendorRepository.GetByGuid(guid);
            if (vendor == null) return false;

            vendor.IsDeleted = true;
            _vendorRepository.Update(vendor);

            return true;
        }
    }
}
