using EasyATM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyATM.Service
{
    public class AccessResult
    {
        public Client Client { get; set; }
        public bool Success { get; set; }
    }

    public class ClientAccessManager
    {
        public static ClientAccessManager Instance
        {
            get
            {
                if (accountManager == null) 
                {
                    accountManager = new ClientAccessManager();
                }

                return accountManager; 
            }
        }

        private static ClientAccessManager accountManager = null;

        private ClientAccessManager()
        {
        }

        public AccessResult Login(int accessNumber) 
        {
            return new AccessResult()
            {
                Client = new Client(ClientType.Default),
                Success = true
            };
        }

    }
}
