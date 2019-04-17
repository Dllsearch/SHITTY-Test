using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace SHITTYTEST
{

    [Serializable]
    public class results // Класс результатов
    {
        [BsonId]
        public Guid Id { get; set; }
        public user User { get; set; } // Пользователь
        public int balls { get; set; } // Набранные очки
        public DateTime DateTime { get; set; } // Дата/время прохождения теста
        public string testName { get; set; } // Назввание теста
    }
}
