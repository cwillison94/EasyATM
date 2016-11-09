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

    public class EasyBankAccount
    {
        public int AccountNumber { private set; get; }
        public float Balance { private set; get; }
        public string Type { private set; get; }
        public Client Client { private set; get; }

        public EasyBankAccount(Client client, DemoAccountType demoAccountType) 
        {
            this.Client = client;

            switch (demoAccountType)
            {
                case DemoAccountType.Demo_Chequing:
                    this.AccountNumber = 21089688;
                    this.Balance = 2000.00F;
                    this.Type = "Chequeing";
                    break;
                case DemoAccountType.Demo_Saving:
                    this.AccountNumber = 210696969;
                    this.Balance = 69000.00F;
                    this.Type = "Saving";
                    break;
            }
        }

        public EasyBankAccount(Client client)
        {
            this.Client = client;
        }

        public bool Withdraw(int amount) 
        {
            //TODO: implement balance checking
            this.Balance -= amount;
            return true;
        }

        public void Deposit(float amount)
        {
            this.Balance += amount;
        }

        public override string ToString()
        {
            return this.Type + " - " + this.AccountNumber;
        }
    }
}
