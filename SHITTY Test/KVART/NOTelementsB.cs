using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHITTYTEST
{
    [Serializable]
    class NOTelementsB
    {
        public Guid Id { get; set; }
        public int[] position { get; set; }
        public elementTypes typeOfElement { get; set; }

        public int[] linkedIndex { get; set; }

        public enum elementTypes
        {
            radio,
            check,
            combo,
            text,
            compare
        };
    }
}
