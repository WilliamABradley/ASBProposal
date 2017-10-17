using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ASBDemo.Models;
using ASBDemo.Enums;
using ASBDemo.Models.Accounts;
using ASBDemo.Models.Transactions;

namespace ASBDemo.Services
{
    public class DemoService : IASBService
    {
        public Task<IReadOnlyList<AccountHistoryItem>> GetAccountHistory(IAccount Account)
        {
            return Task.FromResult((IReadOnlyList<AccountHistoryItem>)new List<AccountHistoryItem>
            {
                new AccountHistoryItem
                {
                    Balance = 531.51m,
                    TransferTime = DateTime.Now,
                    Provider = new MaintenanceTransaction
                    {
                        Type = MaintenanceType.ClosingBalance
                    }
                },
                new AccountHistoryItem
                {
                    CreditAmount = 250m,
                    Balance = 531.51m,
                    TransferTime = DateTime.Now.AddDays(-3),
                    Provider = new TransferTransaction
                    {
                        SenderName = "Bob Ranbury",
                        SenderID = "12-3021-3453434-22",
                        Particulars = "Purchased Bicycle"
                    }
                },
                new AccountHistoryItem
                {
                    DebitAmount = 0.05m,
                    Balance = 281.51m,
                    TransferTime = DateTime.Now.AddDays(-4),
                    Provider = new MaintenanceTransaction
                    {
                        Type = MaintenanceType.SaveTheChange
                    }
                },
                new AccountHistoryItem
                {
                    DebitAmount = 450m,
                    Balance = 281.56m,
                    TransferTime = DateTime.Now.AddDays(-5),
                    Provider = new CardTransaction
                    {
                        CardID = 1212,
                        Retailer = "New World",
                        Location = "Stonefields"
                    }
                },
                new AccountHistoryItem
                {
                    DebitAmount = 100m,
                    Balance = 731.56m,
                    TransferTime = DateTime.Now.AddDays(-5),
                    Provider = new TransferTransaction
                    {
                        SenderName = "Tim Cook",
                        SenderID = "12-3021-4532565-44",
                        Particulars = "Apple Tax"
                    }
                },
                new AccountHistoryItem
                {
                    DebitAmount = 42m,
                    Balance = 831.56m,
                    TransferTime = DateTime.Now.AddDays(-6),
                    Provider = new CardTransaction
                    {
                        CardID = 1116,
                        Retailer = "Computer Lounge",
                        Location = "Auckland"
                    }
                },
                new AccountHistoryItem
                {
                    Balance = 873.56m,
                    TransferTime = DateTime.Now.AddDays(-6),
                    Provider = new MaintenanceTransaction
                    {
                        Type = MaintenanceType.OpeningBalance
                    }
                }
            });
        }

        public Task<IReadOnlyList<BankAccount>> GetAccounts(AccountHolder Holder)
        {
            return Task.FromResult((IReadOnlyList<BankAccount>)new List<BankAccount>
            {
                new BankAccount
                {
                    ID = 12_3021_1234567_89,
                    AvailableBalance = 580.03m,
                    Balance = 580.03m,
                    Name = "Savings",
                    AccountHolder = "MR W A Bradley",
                    Type = AccountType.SavingsOnCall
                },
                new BankAccount
                {
                    ID = 12_3021_1234567_88,
                    AvailableBalance = 22.5m,
                    Balance = 23.5m,
                    Name = "Spendings",
                    AccountHolder = "MR W A Bradley",
                    Type = AccountType.TertiaryAccount
                }
            });
        }

        public Task<IReadOnlyList<InvestScheme>> GetInvestments(AccountHolder Holder)
        {
            return Task.FromResult((IReadOnlyList<InvestScheme>)new List<InvestScheme>
            {
                new InvestScheme
                {
                    ID = "ASBKS123456",
                    Type = InvestSchemeType.KiwiSaver,
                    Balance = 20000.54m,
                    Name = "ASB KiwiSaver Scheme"
                }
            });
        }

        public Task<AccountHolder> GetUser(string Token)
        {
            return Task.FromResult(new AccountHolder
            {
                ID = "123456789ABCDEF123456789ABCDEF",
                Name = "William",
                LastLogin = DateTime.Now.AddDays(-3),
                LastPasswordChange = DateTime.Now.AddMonths(-5)
            });
        }

        public Task<string> GetUserToken(string Username, string Password)
        {
            return Task.FromResult(Guid.NewGuid().ToString());
        }
    }
}