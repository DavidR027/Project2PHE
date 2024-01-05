using Project2PHE.Models;

namespace Project2PHE.Contracts
{
    public interface IAccountRepository : IGeneralRepository<Account>
    {
        Account GetByEmail(string email);
    }
}