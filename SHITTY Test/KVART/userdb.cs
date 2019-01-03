using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace SHITTYTEST
{

    /*
    public class Company
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
    }
    public class User
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }
    */
    [Serializable]
    class userdb
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public permtype Permissions { get; set; }
        public enum permtype
        {
            admin,
            teacher,
            studen,
        }

        public void newone(string username, string password, string name)
        {
            Username = username;
            Password = password;
            Name = name;
        }

        public void callin()
        {

        }

        private void WkaT()
        {

        }

        public void login(string lgn, string pass)
        {

        }
    }
}
