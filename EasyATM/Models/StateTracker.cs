using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EasyATM
{
    public class StateTracker
    {
        private static StateTracker instance = null;

        private Page currentPage = null;
        private Page previousPage = null;

        public Page CurrentPage
        {
            get
            {
                return this.currentPage;
            }
            set
            {
                this.previousPage = this.currentPage;
                this.currentPage = value;
            }
        }

        public Page PreviousPage
        {
            get 
            {
                this.currentPage = this.previousPage;
                return this.previousPage; 
            }
        }

        public static StateTracker Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StateTracker();
                }
                return instance;
            }
        }

        private StateTracker() { }
        

    }
}
