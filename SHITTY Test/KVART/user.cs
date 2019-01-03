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
    public class user
    {
        [BsonId] 
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Group { get; set; }
        public string PermaKey { get; set; }
        public permtype Permissions { get; set; }
        public enum permtype
        {
            admin,
            teacher,
            studen,
            cheater,
            CAHR
        }
        public override string ToString()
        {
            return string.Format("Id:{0},Username:{1},Password:{2},Name:{3},PermaKey:{4},Permissions:{5}",
                Id,
                Username,
                Password,
                Name,
                PermaKey,
                Permissions
                );
        }
    }
}
