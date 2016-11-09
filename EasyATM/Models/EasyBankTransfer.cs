using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyATM.Models
{
    public class EasyBankTransfer
    {
        public EasyBankAccount FromAccount { get; private set; }
        public EasyBankAccount ToAccount { get; private set; }
        public float TransferAmount { get; private set; }

        public string TransferMessage
        {
            get
            {
                return this.TransferAmount.ToString("C") + " FROM " + this.FromAccount.ToString() + " TO " + this.ToAccount.ToString();
            }
        }

        public EasyBankTransfer(EasyBankAccount fromAccount, EasyBankAccount toAccount, float transferAmount)
        {
            this.FromAccount = fromAccount;
            this.ToAccount = toAccount;
            this.TransferAmount = transferAmount;
        }

        public bool Transfer()
        {
            if (this.FromAccount.Withdraw(this.TransferAmount))
            {
                // success - now deposit
                this.ToAccount.Deposit(this.TransferAmount);
                return true;
            }

            return false;
        }
    }
}
