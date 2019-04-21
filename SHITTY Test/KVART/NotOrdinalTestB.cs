using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHITTYTEST
{
    [Serializable]
    class NotOrdinalTestB
    {
        public Guid Id { get; set; }

        public NOTelementsB[] elements { get; set; }

        public int[][] linkedGroups { get; set; }
    }
}
