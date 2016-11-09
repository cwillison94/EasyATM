using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EasyATM.Models
{
    public enum DemoAccountType 
    {
        Demo_Chequing, 
        Demo_Saving
    }

    public enum TransactionType
    {
        Widthdraw, 
        Deposit,
        TransferOut, 
        TransferIn
    }

    public class TransactionItem
    {
        public DateTime Date { get; set; }
        public TransactionType Type { get; set; }
        public string Description { get; set; }
        public float Amount { get; set; }
    }

    public class EasyBankAccount
    {
        public int AccountNumber { private set; get; }
        public float Balance { private set; get; }
        public string BalanceFormatted 
        {
            get
            {
                return this.Balance.ToString("C");
            }
        }
        public string Type { private set; get; }
        public Client Client { private set; get; }

        private List<TransactionItem> transactionHistory = new List<TransactionItem>();

        public EasyBankAccount(Client client, DemoAccountType demoAccountType) 
        {
            this.Client = client;

            switch (demoAccountType)
            {
                case DemoAccountType.Demo_Chequing:
                    this.AccountNumber = 21089688;
                    this.Balance = 2000.00F;
                    this.Type = "Chequeing";
                    PopulateSimulatedHistory();
                    break;
                case DemoAccountType.Demo_Saving:
                    this.AccountNumber = 210696969;
                    this.Balance = 69000.00F;
                    this.Type = "Saving";
                    PopulateSimulatedHistory();
                    break;
            }
        }

        private void PopulateSimulatedHistory()
        {
            this.transactionHistory.Add(new TransactionItem() { Date = DateTime.Now.AddDays(-60), Description = "McMaster University Tution", Amount = -10000.00F, Type = TransactionType.Widthdraw });
            this.transactionHistory.Add(new TransactionItem() { Date = DateTime.Now.AddDays(-3), Description = "McDonalds", Amount = -5.50F, Type = TransactionType.Widthdraw });
            this.transactionHistory.Add(new TransactionItem() { Date = DateTime.Now.AddDays(-2), Description = "ATS Automation - PAY", Amount = 1000.00F, Type = TransactionType.Deposit });
            this.transactionHistory.Add(new TransactionItem() { Date = DateTime.Now.AddDays(-3), Description = "E 109 - Booze", Amount = -21.75F, Type = TransactionType.Widthdraw });
            this.transactionHistory.Add(new TransactionItem() { Date = DateTime.Now.AddDays(-3), Description = "ATM Deposit", Amount = 60.00F, Type = TransactionType.Deposit });
        }

        public List<TransactionItem> ListTransactionHistory()
        {
            return this.transactionHistory;
        }

        public EasyBankAccount(Client client)
        {
            this.Client = client;
        }

        public bool Withdraw(float amount) 
        {
            if (amount > this.Balance)
                return false;
            else
            {
                this.Balance -= amount;
                this.transactionHistory.Add(new TransactionItem() { Date = DateTime.Now, Description = "EasyBank ATM Withdraw", Amount = -amount, Type = TransactionType.Widthdraw });
                return true;
                
            }
        }

        public bool TransferTo(EasyBankAccount toAccount, float amount)
        {
            if (amount > this.Balance)
                return false;
            else 
            {
                this.Balance -= amount;
                toAccount.ReceiveTransfer(this, amount);
                this.transactionHistory.Add(new TransactionItem() { Date = DateTime.Now, Description = "Transfer to " + toAccount.ToString(), Amount = -amount, Type = TransactionType.TransferOut });
                return true;
            }
        }

        private void ReceiveTransfer(EasyBankAccount fromAccount, float amount)
        {
            this.Balance += amount;
            this.transactionHistory.Add(new TransactionItem() { Date = DateTime.Now, Description = "Received Transfer From " + fromAccount.ToString(), Amount = amount, Type = TransactionType.TransferIn });

        }

        public void Deposit(float amount)
        {
            this.Balance += amount;
            this.transactionHistory.Add(new TransactionItem() { Date = DateTime.Now, Description = "EasyBank Deposit", Amount = amount, Type = TransactionType.Deposit });
        }

        public override string ToString()
        {
            return this.Type + " - " + this.AccountNumber;
        }
    }
}
