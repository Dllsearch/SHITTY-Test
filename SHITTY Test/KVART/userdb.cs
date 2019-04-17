using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace SHITTYTEST
{
    [Serializable]
    class userdb
    {
        public Guid Id { get; set; }
        public string Username { get; set; } // Ник
        public string Password { get; set; } // Пароль
        public string Name { get; set; } // ФИО
        public permtype Permissions { get; set; }
        public enum permtype // Типы прав доступа
        {
            admin,
            teacher,
            studen,
        }

        public void newone(string username, string password, string name) // Создать ещё одну запись
        {
            Username = username;
            Password = password;
            Name = name;
        }
        // Дальше пустые неиспользуемые функции
        public void callin() // При вызове
        {

        }

        private void WkaT() // При запросе
        {

        }

        public void login(string lgn, string pass) // Логин
        {

        }
    }
}
