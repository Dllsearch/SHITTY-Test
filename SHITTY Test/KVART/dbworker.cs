using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using LiteDB;

namespace SHITTYTEST
{
    /*  Класс для работы с БД
     * Методы записи тестов, загрузки файлов, получения тестов
     * Редактирования записей, работа с пользователями
    */
    class DBworker
    {
        public void addResult(user user, int bs, string tstnm) //Добавляет результат
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var results = db.GetCollection<results>("Results");
                DateTime dateTime = DateTime.Now; // Время сейчас
                // Создаёт обьект результата
                var res = new results { User = user, balls = bs, DateTime = dateTime, testName = tstnm };
                results.Insert(res); // Запись обьекта в БД
                //MessageBox.Show("Тест добавлен успешно!");
            }
        }

        public List<results> getResults() // Возвращает результаты
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var Results = db.GetCollection<results>("Results");

                // Индексируем документ по определенному свойству
                Results.EnsureIndex(x => x.DateTime);
                var vResults = Results.FindAll(); // Ищем все результаты
                List<results> res = new List<results>(); // Создаем лист с результатами
                foreach (results fResults in vResults) // Каждый добавляем в лист
                {
                    res.Add(fResults);
                }
                return res;
            }
        }

        public string[][] getResultsString()
        // Возвращает результаты с разделенной по столбцам информацией
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var Results = db.GetCollection<results>("Results");

                // Индексируем документ по определенному свойству
                Results.EnsureIndex(x => x.DateTime);
                var vResults = Results.FindAll();
                List<results> res = new List<results>();
                int r = 0; // Счетчик
                foreach (results fResults in vResults)
                {
                    res.Add(fResults);
                    r++;
                }
                string[][] msv = new string[r][]; // 2м масив, 1размер - счетчик
                for (int x = 0; x < r; x++)
                {
                    msv[x] = new string[5]; // Инициализируем 2й размер
                }
                for (int x = 0; x < r; x++) // забиваем массив результатами
                {
                    msv[x][0] = res[x].User.Name;
                    msv[x][1] = res[x].User.Group;
                    msv[x][2] = res[x].testName;
                    msv[x][3] = res[x].balls.ToString();
                    msv[x][4] = res[x].DateTime.ToString();
                }
                return msv;
            }
        }

        public void newTest(string name, string user, string link) //Добавить тест
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var tests = db.GetCollection<Test>("Tests");
                if (checkTest(name) != null)
                {
                    MessageBox.Show("Тест с таким именем уже существует!");
                }
                else
                {
                    //Получаем имя файла, транслителируем, убираем пробелы, использууем строчные
                    string cLink = Translit(link.Split('\\').Last().Split('.').Last().Trim(' ').ToLower());
                    //Называем файл теста рандомным именем (чтоб хитрые студенты хоть немного подумали)
                    Random random = new Random();
                    // Создаём обьект теста
                    var test = new Test { Name = name, User = user, fileName = random.Next().ToString() };
                    db.FileStorage.Upload(test.fileName, link); //загружаем файл в БД, с id в виде имени
                    tests.Insert(test);
                    MessageBox.Show("Тест добавлен успешно!");
                }
            }
        }

        // Если вы дочитали до этого места, и вас не стошнило, ил вы не упали в обмарок от такого говнокода,
        // Хочу выразить вам моё уважение, а то меня самого от себя тошнит, когда читаю это.

        public Test checkTest(string name) //Возвращает тест, отличие в NULL в инициализации
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var tests = db.GetCollection<Test>("Tests");

                // Индексируем документ по определенному свойству
                tests.EnsureIndex(x => x.Name);
                //Ищем тест с совпадающим именем
                var vtest = tests.Find(x => x.Name.Equals(name));
                Test test = null;
                foreach (Test ftest in vtest)
                {
                    test = ftest;   
                }
                return test;
            }
        }

        public shitcomp getTest(string name) // Возвращает объект теста
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var tests = db.GetCollection<Test>("Tests");

                // Индексируем документ по определенному свойству
                tests.EnsureIndex(x => x.Name);
                var vtest = tests.Find(x => x.Name.Equals(name)); // Поиск по совпадению
                Test test = null;
                foreach (Test ftest in vtest)
                {
                    test = ftest;
                }
                if (test == null) return null;
                var stream = db.FileStorage.OpenRead(test.fileName); // Читаем с Файлопомойки БД
                shitcomp sc; // Под объект
                using (Stream input = stream)
                {
                    BinaryFormatter formatter = new BinaryFormatter(); // Читаем обьект
                    sc = (shitcomp)formatter.Deserialize(input); // Пишем объект
                }
                return sc;
            }
        }

        public List <Test> getTests() // Список тестов
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var tests = db.GetCollection<Test>("Tests");

                // Индексируем документ по определенному свойству
                tests.EnsureIndex(x => x.Name);
                var vtest = tests.FindAll();
                List<Test> Tests = new List<Test>();
                foreach (Test ftest in vtest)
                {
                    Tests.Add(ftest);
                }
                return Tests;
            }
        }

        public bool indexofbool(string source, string value, StringComparison comparisonType)
        {
            // просто проверка на существование заданной последовательности в строке
            if (source.IndexOf(value, comparisonType) != -1) return true;
            else return false;
        }

        public List<Test> findTests(string qnme) // Возвращает тесты по запросу
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var tests = db.GetCollection<Test>("Tests");

                // Индексируем документ по определенному свойству
                tests.EnsureIndex(x => x.Name);
                var vtest = tests.Find(x => indexofbool(x.Name, qnme, StringComparison.OrdinalIgnoreCase));
                List<Test> Tests = new List<Test>();
                foreach (Test ftest in vtest)
                {
                    Tests.Add(ftest);
                }
                return Tests;
            }
        }

        public void delTest(string what) // УДОЛЯИТ тесты
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var tests = db.GetCollection<Test>("Tests");

                // Индексируем документ по определенному свойству
                tests.EnsureIndex(x => x.Name);
                var vtest = tests.Find(x => x.Name.Equals(what));
                Test test = new Test();
                foreach (Test ftest in vtest)
                {
                    test = ftest;
                }
                db.FileStorage.Delete(test.fileName);
                tests.Delete(x => x.Name.Equals(what));
            }
        }

        private user.permtype pkdec (string permakey) // говнокод для прав
        {
            user.permtype acc = user.permtype.studen;
            if (permakey == "students") acc = user.permtype.studen;
            if (permakey == "student") acc = user.permtype.studen;
            else if (permakey == "MKTHR") acc = user.permtype.teacher;
            else if (permakey == "MKDMN") acc = user.permtype.admin;
            return acc;
        }



        public void newUser(string name, string username, string pass, string group,  string permakey)
            //Добавить юзера
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                user.permtype acc = user.permtype.studen;
                // Получаем коллекцию
                var users = db.GetCollection<user>("Users");
                if (getUser(username) != null)
                {
                    MessageBox.Show("Логин занят!");
                }
                else
                {
                    if (permakey != null && permakey != "")
                    {
                        acc = pkdec(permakey);
                    }
                    else acc = user.permtype.studen;
                    var User = new user { Username = username, Password = pass, Name = name, Group = group, Permissions = acc };
                    users.Insert(User);
                }
            }
        }

        public void addUser(string name, string username, string pass, string group, user.permtype perms)
        //Добавить юзера
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var users = db.GetCollection<user>("Users");
                if (getUser(username) != null)
                {
                    MessageBox.Show("Логин занят!");
                }
                else
                {
                    var user = new user { Username = username, Password = pass, Name = name, Group = group, Permissions = perms };
                    users.Insert(user);
                }
            }
        }

        public user login (string username, string pass) //Проверка Логин+пароль
        {
            user user = getUser(username);
            if (user != null && user.Username == username)
            {
                if (user.Password == pass)
                {
                    MessageBox.Show("WELLCOME, " + user.Name, "LOG-IN");
                    return user;
                }
                else
                {
                    MessageBox.Show("Incorrect password", "LOG-IN");
                    return null;
                }
            }
            else 
            {
                MessageBox.Show("Incorrect username", "LOG-IN");
                return null;
            }
        }
        
        public user getUser(string username) //Возвращает юзера
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var users = db.GetCollection<user>("Users");

                // Индексируем документ по определенному свойству
                users.EnsureIndex(x => x.Username);
                var vuser = users.Find(x => x.Username.Equals(username));
                user user = null;
                foreach (user fuser in vuser)
                {
                    user = fuser;
                }
                return user;
            }
        }

        public user getUserByID(string uid) //Возвращает юзера
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var users = db.GetCollection<user>("Users");

                // Индексируем документ по определенному свойству
                users.EnsureIndex(x => x.Username);
                Guid tid = new Guid(uid);
                var vuser = users.Find(x => x.Id.Equals(tid));
                user user = null;
                foreach (user fuser in vuser)
                {
                    user = fuser;
                }
                return user;
            }
        }

        public List<user> getUsers(string username) //Тож самое, но лист
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var users = db.GetCollection<user>("Users");

                // Индексируем документ по определенному свойству
                users.EnsureIndex(x => x.Username);
                var vuser = users.Find(x => x.Username.Equals(username));
                List<user> Users = null;
                foreach (user fuser in vuser)
                {
                    Users.Add(fuser);
                }
                return Users;
            }
        }

        public string[][] getUsersString() //Тож самое, но массив строк
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var users = db.GetCollection<user>("Users");

                // Индексируем документ по определенному свойству
                users.EnsureIndex(x => x.Username);
                var vuser = users.FindAll();
                List<user> Users = new List<user>();
                int r = 0;
                foreach (user fuser in vuser)
                {
                    Users.Add(fuser);
                    r++;
                }
                string[][] msv = new string[r][]; // 2м масив, 1размер - счетчик
                for (int x = 0; x < r; x++)
                {
                    msv[x] = new string[5]; // Инициализируем 2й размер
                }
                for (int x = 0; x < r; x++) // забиваем массив результатами
                {
                    msv[x][0] = Users[x].Username;
                    msv[x][1] = Users[x].Name;
                    msv[x][2] = ""+Users[x].Permissions;
                    msv[x][3] = Users[x].Password;
                    msv[x][4] = ""+Users[x].Id;
                }
                return msv;
            }
        }

        public List<user> getUsersByGroup(string group) //По группам!
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var users = db.GetCollection<user>("Users");

                // Индексируем документ по определенному свойству
                List<user> Users = null;
                users.EnsureIndex(x => x.Username);
                var vuser = users.Find(x => x.Group.Equals(group));
                foreach (user fuser in vuser)
                {
                    Users.Add(fuser);
                }
                return Users;
            }
        }

        public user getUserByName(string name) // Я позову тебя тихо по имени...
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var users = db.GetCollection<user>("Users");

                // Индексируем документ по определенному свойству
                users.EnsureIndex(x => x.Name);
                var vuser = users.Find(x => x.Username.Equals(name));
                user user = null;
                foreach (user fuser in vuser)
                {
                    user = fuser;
                }
                return user;
            }
        }

        public void setUser(Guid userid, user upduser) 
            // Сменить Логин+пароль, форму пилить лень, но метод же есть? Щитаеца!
        { 
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var users = db.GetCollection<user>("Users");

                // Индексируем документ по определенному свойству
                users.EnsureIndex(x => x.Id);
                var vuser = users.Find(x => x.Id.Equals(userid));
                users.Update(upduser);
            }
        }

        public void delUser(Guid did) // УДОЛЯИТ пользователей
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var Users = db.GetCollection<user>("Users");

                // Индексируем документ по определенному свойству
                Users.EnsureIndex(x => x.Id);
                var vUser = Users.Find(x => x.Id.Equals(did));
                user User = null;
                foreach (user fUser in vUser)
                {
                    User = fUser;
                }
                Users.Delete(x => x.Id.Equals(did));
            }
        }

        public static string Translit(string str) //Страшная махина для транслитерации, не моё.
        {
            string[] lat_up = { "A", "B", "V", "G", "D", "E", "Yo", "Zh", "Z", "I", "Y", "K", "L", "M", "N", "O", "P", "R", "S", "T", "U", "F", "Kh", "Ts", "Ch", "Sh", "Shch", "\"", "Y", "'", "E", "Yu", "Ya" };
            string[] lat_low = { "a", "b", "v", "g", "d", "e", "yo", "zh", "z", "i", "y", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "kh", "ts", "ch", "sh", "shch", "\"", "y", "'", "e", "yu", "ya" };
            string[] rus_up = { "А", "Б", "В", "Г", "Д", "Е", "Ё", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ы", "Ь", "Э", "Ю", "Я" };
            string[] rus_low = { "а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я" };
            for (int i = 0; i <= 32; i++)
            {
                str = str.Replace(rus_up[i], lat_up[i]);
                str = str.Replace(rus_low[i], lat_low[i]);
            }
            return str;
        }
    }
}