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
        private Table<User> usersTable;
        private DataContext context;

        public UserManager()
        {
            string connectionString =
              ConfigurationManager.ConnectionStrings["AppDb"].ConnectionString;
            context = new DataContext(connectionString);
            usersTable = context.GetTable<User>();
        }

        public User GetUserByUserName(string userName, string passWord)
        {
            User user = usersTable.SingleOrDefault(
              u => u.UserName == userName && u.Password == passWord);
            return user;
        }

        public User GetUserByUserName(string userName)
        {
            User user = usersTable.SingleOrDefault(u => u.UserName == userName);
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return usersTable.AsEnumerable();
        }

        public int RegisterUser(User User)
        {
            User user = new User();
            user.UserName = User.UserName;
            user.Password = User.Password;
            user.UserEmailAddress = User.UserEmailAddress;

            usersTable.InsertOnSubmit(user);
            context.SubmitChanges();

            return user.UserID;
        }
    }
}
