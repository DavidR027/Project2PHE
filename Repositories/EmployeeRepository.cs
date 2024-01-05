using Project2PHE.Contexts;
using Project2PHE.Contracts;
using Project2PHE.Models;

namespace Project2PHE.Repositories
{
    public class EmployeeRepository : GeneralRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RegisterDbContext context) : base(context)
        {
        }
    }
}
