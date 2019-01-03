using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace SHITTYTEST
{

    [Serializable]
    public class results
    {
        [BsonId]
        public Guid Id { get; set; }
        public user User { get; set; }
        public int balls { get; set; }
        public DateTime DateTime { get; set; }
        public string testName { get; set; }
    }
}
