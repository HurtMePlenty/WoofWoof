using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DALTypes;

namespace DAL
{
    public class UserManager
    {

        private readonly MainDBEntities _db;

        public UserManager(string connectionStringName)
        {
            string connectionString =
              ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            _db = new MainDBEntities(connectionString);

        }

        public User GetUser(string userName, string passWord)
        {
            User user = _db.Users.SingleOrDefault(
              u => u.UserName == userName && u.Password == passWord);
            return user;
        }

        public bool Validate(string userName, string password)
        {
            return _db.Users.Any(u => u.UserName == userName && u.Password == password);
        }

        public User GetUser(string userName)
        {
            User user = _db.Users.SingleOrDefault(u => u.UserName == userName);
            return user;
        }

        public IEnumerable<User> GetUsers()
        {
            return _db.Users.AsEnumerable();
        }

        public int RegisterUser(User user)
        {
            _db.Users.Add(user);
            _db.SaveChanges();
            return user.UserID;
        }
    }
}
