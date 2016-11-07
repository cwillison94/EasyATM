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

    public class Account
    {
        public int AccountNumber { private set; get; }
        public int Balance { private set; get; }
        public string Type { private set; get; }

        private ICommand viewAccountCommand = null;

        public Account(DemoAccountType demoAccountType) 
        {
            switch (demoAccountType)
            {
                case DemoAccountType.Demo_Chequing:
                    this.AccountNumber = 21089688;
                    this.Balance = 2000;
                    this.Type = "Chequeing";
                    break;
                case DemoAccountType.Demo_Saving:
                    this.AccountNumber = 210696969;
                    this.Balance = 69000;
                    this.Type = "Saving";
                    break;
            }
        }

        public Account()
        {
 
        }

        public void Withdraw(int amount) 
        {
            this.Balance -= amount;
        }

        public ICommand ViewAccountCommand
        {
            get 
            { 
                if (this.viewAccountCommand == null)
                {
                    this.viewAccountCommand = new RelayCommand(x => this.ViewAccount()); 
                }

                return this.viewAccountCommand;
            }
        }

        private void ViewAccount()
        {
            System.Diagnostics.Debug.WriteLine("View Account " + this.AccountNumber);
        }
    }
}
