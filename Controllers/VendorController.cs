using System.Web.Mvc;
using Project2PHE.Services;
using Project2PHE.DTOs.Vendors;
using Project2PHE.Contexts;
using Project2PHE.Repositories;
using Project2PHE.ViewModels;
using Project2PHE.Models;
using System.Linq;
using System.IO;
using System;
using System.Data.Entity.Infrastructure;

namespace Project2PHE.Controllers
{
    public class VendorController : Controller
    {
        private readonly VendorServices _vendorServices;

        public VendorController()
        {
            var context = new RegisterDbContext();
            _vendorServices = new VendorServices(new VendorRepository(context), new AccountRepository(context), context);
        }

        // GET: Vendor
        public ActionResult Index()
        {
            var vendorDtos = _vendorServices.GetAllVendor();
            var vendors = vendorDtos.Select(dto => (Vendor)dto).ToList();
            return View(vendors);
        }

        // GET: Vendor/Details/5
        public ActionResult Details(string id)
        {
            var vendor = _vendorServices.GetVendorByGuid(id);
            return View(vendor);
        }

        // GET: Vendor/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Registers()
        {
            return View(new RegisterViewModel());
        }

        // POST: Register
        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            byte[] photoBytes = new byte[0];
            if (model.UploadedPhoto != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    model.UploadedPhoto.InputStream.CopyTo(memoryStream);
                    photoBytes = memoryStream.ToArray();
                }
            }

            var registerDto = new RegisterDTO
            {
                CompanyName = model.Vendor.CompanyName,
                Address = model.Vendor.Address,
                CompanyEmail = model.Vendor.CompanyEmail,
                Phone = model.Vendor.Phone,
                Photo = photoBytes,
                Password = model.Account.Password
            };

            _vendorServices.RegisterVendor(registerDto);

            return RedirectToAction("Registers");
        }

        [HttpPost]
        public ActionResult ApproveVendor(string guid)
        {
            var result = _vendorServices.ApproveVendor(guid);

            if (result)
            {
                // Vendor was approved successfully
                return RedirectToAction("Index");
            }
            else
            {
                // Vendor approval failed
                ModelState.AddModelError("", "Vendor approval failed.");
                return View("Index");
            }
        }

        [HttpPost]
        public ActionResult RejectVendor(string guid)
        {
            var result = _vendorServices.RejectVendor(guid);

            if (result)
            {
                // Vendor was rejected successfully
                return RedirectToAction("Index");
            }
            else
            {
                // Vendor rejection failed
                ModelState.AddModelError("", "Vendor rejection failed.");
                return View("Index");
            }
        }

        // POST: Vendor/Create
        [HttpPost]
        public ActionResult Create(NewVendorDTO vendorDto)
        {
            try
            {
                _vendorServices.CreateVendor(vendorDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vendor/Edit/5
        public ActionResult Edit(string id)
        {
            var vendor = _vendorServices.GetVendorByGuid(id);
            return View(vendor);
        }

        // POST: Vendor/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, VendorDTO vendorDto)
        {
            try
            {
                _vendorServices.UpdateVendor(vendorDto);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vendor/Delete/5
        public ActionResult Delete(string id)
        {
            var vendor = _vendorServices.GetVendorByGuid(id);
            return View(vendor);
        }

        // POST: Vendor/Delete/5
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            try
            {
                _vendorServices.DeleteVendor(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}