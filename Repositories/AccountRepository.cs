using Project2PHE.Contexts;
using Project2PHE.Contracts;
using Project2PHE.Models;
using System.Linq;

namespace Project2PHE.Repositories
{
    public class AccountRepository : GeneralRepository<Account>, IAccountRepository
    {
        private readonly RegisterDbContext _context;
        public AccountRepository(RegisterDbContext context) : base(context)
        {
            _context = context;
        }

        public Account GetByEmail(string email)
        {
            var account = _context.Accounts
            .Include("VendorNavigation")
            .Include("EmployeeNavigation")
            .FirstOrDefault(a =>
            (a.VendorNavigation != null && a.VendorNavigation.CompanyEmail == email) ||
            (a.EmployeeNavigation != null && a.EmployeeNavigation.Email == email));

            return account;
        }

    }
}
