using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyATM.Models
{
    public enum ClientType
    { 
        Default = -1
    }

    public class Client
    {
        private List<EasyBankAccount> accounts = new List<EasyBankAccount>();

        public string FirstName { private set; get; }
        public string LastName { private set; get; }

        public string FullName 
        {
            get
            {
                return this.LastName + ", " + this.FirstName;
            }
        }

        public string WelcomeMessage
        {
            get
            {
                return "Welcome " + this.FullName + "!";
            }
        }

        public Client(ClientType clientType)
        {
            if (clientType == ClientType.Default)
            {
                this.FirstName = "Cole";
                this.LastName = "Willison";

                this.accounts.Add(new EasyBankAccount(this, DemoAccountType.Demo_Chequing));
                this.accounts.Add(new EasyBankAccount(this, DemoAccountType.Demo_Saving));
            }
        }

        public List<EasyBankAccount> ListAccounts()
        {
            return this.accounts;
        }

        public EasyBankAccount GetAccount(int accountNumber)
        {
            return this.accounts.First(x => x.AccountNumber == accountNumber);
        }
    }
}

