using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace SHITTYTEST
{
    public class Test // Запись теста
    {
        [BsonId]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string User { get; set; }
        public string fileName { get; set; }
    }
}