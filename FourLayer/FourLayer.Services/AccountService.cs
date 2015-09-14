using AutoMapper;
using FourLayer.Domain.Models;
using FourLayer.Infrastructure.Models;
using FourLayer.Services.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace FourLayer.Services
{

    public class AccountService
    {
        /*

        Open a new account x
        Transfer money between accounts
        Get my balance x
        Close an account x

        */
        private IRepository _repo;

        public AccountService(IRepository repo)
        {
            _repo = repo;
        }

        //Works
        public IList<AccountDTO> ListAccounts()
        {
            var dtoList = new List<AccountDTO>();
            foreach (Account a in _repo.Query<Account>().ToList())
            {
                dtoList.Add(Mapper.Map<AccountDTO>(a));
            }

            return dtoList;
        }


        // JD, Keenan and Tom's Solution 
        //public AccountDTO FindAccount(string username)
        //{
        //    var targetAccount = _repo.Query<Account>().FirstOrDefault(t => t.Username == username);
        //    AccountDTO accountDTO = Mapper.Map<AccountDTO>(targetAccount);

        //    return accountDTO;

        //}

        // JD, Keenan and Tom's Solution 
        public AccountDTO FindAccount(string accountNum)
        {
            var targetAccount = _repo.Query<Account>().FirstOrDefault(t => t.AccountNumber == accountNum);
            AccountDTO accountDTO = Mapper.Map<AccountDTO>(targetAccount);

            return accountDTO;

        }

        //public void WriteDB(AccountDTO account)
        //{
        //   var targetAccount = _repo.Query<Account>().FirstOrDefault(t => t.Username == account.Username);                             
        //    targetAccount.Balance = account.Balance;
        //    _repo.SaveChanges();

        //}

        //Works
        private string GenerateAccount()
        {
            Random rnd = new Random();
                                                     //9,000,000,000 + 1,000,000,000
            long accountNumber = (long)(rnd.NextDouble() * 9000000000L + 1000000000L);
            return accountNumber.ToString();            

        }

        //Works
        public AccountDTO OpenAccount(string username, string accountType, decimal startingBalance)
        {
            Account account = new Account
            {
                Username = username,
                AccountType = accountType,
                Balance = startingBalance,
                AccountNumber = GenerateAccount()

            };

            _repo.Add<Account>(account);
            _repo.SaveChanges();

            return Mapper.Map<AccountDTO>(account);
        }

        //JD Solution?
        public void DeleteAccount(string accountNumber)
        {
            var targetAccount = _repo.Query<Account>().FirstOrDefault(t => t.AccountNumber == accountNumber);
            int id = targetAccount.Id;
            _repo.Delete<Account>(id);
//_repo.Delete<AccountDTO>(id);          
            _repo.SaveChanges();
        }

        
        //JDs Solution?
        public decimal GetBalance(Account account)
        {
            decimal balance = _repo.Find<Account>(account.Id).Balance;
            return balance;
        }

        //?
        public void TransferBalance(string accountNumberFrom, string accountNumberTo, decimal balance)
        { 
            var from = (from a in _repo.Query<Account>()
                        where a.AccountNumber == accountNumberFrom
                        select a).FirstOrDefault();

            var to = (from a in _repo.Query<Account>()
                      where a.AccountNumber == accountNumberTo
                      select a).FirstOrDefault();

            from.Balance = from.Balance - balance;
            to.Balance = to.Balance + balance;
            _repo.SaveChanges();

        }

        public void SaveAccount(AccountDTO account)
        {
            if (account.Username != "" && account.AccountType != "")
            {
                var targetAccount = _repo.Query<Account>().FirstOrDefault(t => t.AccountNumber == account.AccountNumber);
               
                targetAccount.Username = account.Username;
                targetAccount.AccountType = account.AccountType;
                targetAccount.Balance = account.Balance;

            }

            else
            {
                _repo.Add(account);
            }
            _repo.SaveChanges();
        }

    }
    
}
