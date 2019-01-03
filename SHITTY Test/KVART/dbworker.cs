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
    class dbworker
    {
        public void addResult(user user, int bs, string tstnm)
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var results = db.GetCollection<results>("Results");
                DateTime dateTime = DateTime.Now;
                var res = new results { User = user, balls = bs, DateTime = dateTime, testName = tstnm };
                results.Insert(res);
                //MessageBox.Show("Тест добавлен успешно!");
            }
        }

        public List<results> getResults()
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
                foreach (results fResults in vResults)
                {
                    res.Add(fResults);
                }
                return res;
            }
        }

        public string[][] getResultsString()
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
                int r = 0;
                foreach (results fResults in vResults)
                {
                    res.Add(fResults);
                    r++;
                }
                string[][] msv = new string[r][];
                for (int x = 0; x < r; x++)
                {
                    msv[x] = new string[5];
                }
                for (int x = 0; x < r; x++)
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

        public void newTest(string name, string user, string link)
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
                    string cLink = Translit(link.Split('\\').Last().Split('.').Last().Trim(' ').ToLower());
                    Random random = new Random();
                    var test = new Test { Name = name, User = user, fileName = random.Next().ToString() };
                    //link = Translit(link.ToLower().Trim(' '));
                    db.FileStorage.Upload(test.fileName, link);
                    tests.Insert(test);
                    MessageBox.Show("Тест добавлен успешно!");
                }
            }
        }

        public Test checkTest(string name)
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var tests = db.GetCollection<Test>("Tests");

                // Индексируем документ по определенному свойству
                tests.EnsureIndex(x => x.Name);
                var vtest = tests.Find(x => x.Name.Equals(name));
                Test test = null;
                foreach (Test ftest in vtest)
                {
                    test = ftest;
                }
                return test;
            }
        }

        public shitcomp getTest(string name)
        {
            // открывает базу данных, если ее нет - то создает
            using (var db = new LiteDatabase(@"main.db"))
            {
                // Получаем коллекцию
                var tests = db.GetCollection<Test>("Tests");

                // Индексируем документ по определенному свойству
                tests.EnsureIndex(x => x.Name);
                var vtest = tests.Find(x => x.Name.Equals(name));
                Test test = new Test();
                foreach (Test ftest in vtest)
                {
                    test = ftest;
                }
                var stream = db.FileStorage.OpenRead(test.fileName);
                shitcomp sc;
                using (Stream input = stream)
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    sc = (shitcomp)formatter.Deserialize(input);
                }
                return sc;
            }
        }

        public List <Test> getTests()
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


        public void delTest(string what)
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

        private user.permtype pkdec (string permakey)
        {
            user.permtype acc = user.permtype.studen;
            if (permakey == "students") acc = user.permtype.studen;
            if (permakey == "student") acc = user.permtype.studen;
            else if (permakey == "MKTHR") acc = user.permtype.teacher;
            else if (permakey == "MKDMN") acc = user.permtype.admin;
            return acc;
        }



        public void newUser(string name, string username, string pass, string group,  string permakey)
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
                    if (permakey != null)
                    {
                        acc = pkdec(permakey);
                    }
                    var user = new user { Username = username, Password = pass, Name = name, Group = group, Permissions = acc };
                    users.Insert(user);
                }
                //microsoft.Users = new List<User> { new User { Name = "Bill Gates" } };
                
                // Добавляем компанию в коллекцию

                // Обновляем документ в коллекции
                //microsoft.Name = "Microsoft Inc.";
                //col.Update(microsoft);

                /*
                var google = new Company { Name = "Google" };
                google.Users = new List<User> { new User { Name = "Larry Page" } };
                col.Insert(google);
                */
            } }

        public user login (string username, string pass)
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
        
        public user getUser(string username)
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

        public List<user> getUsers(string username)
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

        public List<user> getUsersByGroup(string group)
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

        public user getUserByName(string name)
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

        public void setUser(string username, string password)
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
                user.Password = password;
                users.Update(user);
            }
        }

        public static string Translit(string str)
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
        /*

            }
            // Получаем все документы
            var result = col.FindAll();
                foreach (Company c in result)
                {
                    Console.WriteLine(c.Name);
                    foreach (User u in c.Users)
                        Console.WriteLine(u.Name);
                    Console.WriteLine();
                }

                // Индексируем документ по определенному свойству
                col.EnsureIndex(x => x.Name);

                col.Delete(x => x.Name.Equals("Google"));

                Console.WriteLine("После удаления Google");
                result = col.FindAll();
                foreach (Company c in result)
                {
                    Console.WriteLine(c.Name);
                    foreach (User u in c.Users)
                        Console.WriteLine(u.Name);
                    Console.WriteLine();
                }
        }
        */