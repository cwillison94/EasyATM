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
        public string FirstName { private set; get; }
        public string LastName { private set; get; }

        private List<EasyBankAccount> accounts = new List<EasyBankAccount>();

        public string WelcomeMessage
        {
            get
            {
                return "Welcome " + this.LastName + ", " + this.FirstName + "!";
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
    }
}

