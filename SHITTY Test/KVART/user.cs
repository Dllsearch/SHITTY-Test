using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;

namespace SHITTYTEST
{
    [Serializable]
    public class user
    {
        [BsonId] 
        public Guid Id { get; set; }
        public string Username { get; set; } //Ник
        public string Password { get; set; } //Парол
        public string Name { get; set; } //Имя
        public string Group { get; set; } //Группа
        public string PermaKey { get; set; } //Рудимент
        public permtype Permissions { get; set; } // Права юзера
        public enum permtype //список прав
        {
            admin,
            teacher,
            studen,
            cheater,
            CAHR
        }
        public override string ToString() //возвращает юзерку строкой (нахрена?)
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
