using Project2PHE.Contracts;
using Project2PHE.DTOs.Accounts;
using Project2PHE.Models;
using Project2PHE.Repositories;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Project2PHE.Services
{
    public class AccountServices
    {
        private readonly IAccountRepository _accountRepository;

        public AccountServices(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;

        }

        public IEnumerable<AccountDTO> GetAllAccount()
        {
            var Accounts = _accountRepository.GetAll();

            if (!Accounts.Any()) return Enumerable.Empty<AccountDTO>();

            var getAccounts = new List<AccountDTO>();

            foreach (var Account in Accounts)
            {
                getAccounts.Add(new AccountDTO
                {
                    Guid = Account.Guid,
                    Role = Account.Role,
                    Password = Account.Password,
                });
            }

            return getAccounts;
        }

        public AccountDTO GetAccountByGuid(string guid)
        {
            var Account = _accountRepository.GetByGuid(guid);
            if (Account == null) return null;

            // Map the Account to a AccountDTO
            var AccountDto = new AccountDTO
            {
                Guid = Account.Guid,
                Role = Account.Role,
                Password = Account.Password,
            };

            return AccountDto;
        }

        public AccountDTO GetAccountByEmail(string email)
        {
            var account = _accountRepository.GetByEmail(email);
            if (account == null) return null;

            // Map the Account to an AccountDTO
            var accountDto = new AccountDTO
            {
                Guid = account.Guid,
                Role = account.Role,
                Password = account.Password,
            };

            return accountDto;
        }

        public AccountDTO UpdateAccount(AccountDTO AccountDto)
        {
            var Account = _accountRepository.GetByGuid(AccountDto.Guid);
            if (Account == null) return null;

            //Update
            Account.Guid = AccountDto.Guid;
            Account.Role = AccountDto.Role;
            Account.Password = AccountDto.Password;

            _accountRepository.Update(Account);
            return AccountDto;
        }

        public bool DeleteAccount(string guid)
        {
            var Account = _accountRepository.GetByGuid(guid);
            if (Account == null) throw new Exception("Account not found");

            return _accountRepository.Delete(Account);
        }
    }
}
