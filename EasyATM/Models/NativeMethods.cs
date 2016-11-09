using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyATM.Models
{
    public class NativeMethods
    {
        /// Return Type: BOOL->int
        ///fBlockIt: BOOL->int
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "BlockInput")]
        [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        public static extern bool BlockInput([System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)] bool fBlockIt);

    }
}
