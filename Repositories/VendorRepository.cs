using Project2PHE.Contexts;
using Project2PHE.Contracts;
using Project2PHE.Models;

namespace Project2PHE.Repositories
{
    public class VendorRepository : GeneralRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(RegisterDbContext context) : base(context)
        {
        }

    }
}
