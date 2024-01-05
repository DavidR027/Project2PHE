using Project2PHE.Models;
using System;

namespace Project2PHE.DTOs.Accounts
{
    public class AccountDTO
    {
        public string Guid { get; set; } = null;
        public string Role { get; set; }
        public string Password { get; set; }

        public static implicit operator Account(AccountDTO accountDTO)
        {
            return new Account
            {
                Guid = accountDTO.Guid,
                Role = accountDTO.Role,
                Password = accountDTO.Password,
            };
        }

        public static explicit operator AccountDTO(Account account)
        {
            return new AccountDTO
            {
                Guid = account.Guid,
                Role = account.Role,
                Password = account.Password,
            };
        }
    }
}