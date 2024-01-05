using Project2PHE.Models;
using System.Web;

namespace Project2PHE.ViewModels
{
    public class RegisterViewModel
    {
        public Account Account { get; set; }
        public Vendor Vendor { get; set; }
        public HttpPostedFileBase UploadedPhoto { get; set; }
    }

}