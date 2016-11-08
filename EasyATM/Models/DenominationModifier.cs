using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyATM.Models
{
    public class DenominationModifier
    {
        public int FaceValue { get; private set; }
        public int DenominationTotal { get; private set; }
        public int TotalValue { get { return this.FaceValue * this.DenominationTotal; } }

        public DenominationModifier(int faceValue)
        {
            this.FaceValue = faceValue;
            this.DenominationTotal = 0;
        }

        public void Increment()
        {
            this.DenominationTotal++;
        }

        public void Decrement()
        {
            if (this.DenominationTotal > 0)
            {
                this.DenominationTotal--;
            }
        }
    }
}
