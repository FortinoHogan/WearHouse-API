using Microsoft.AspNetCore.Mvc;
using WearHouse_API_Revision.Datas;
using WearHouse_API_Revision.Models;

namespace WearHouse_API_Revision.Helpers
{
    public class UserHelper
    {
        private AppDbContext _dbContext;
        public UserHelper(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User GetUserById(string email)
        {
            var user = (from u in _dbContext.User
                        where u.UserEmail == email
                        select u).FirstOrDefault();
            if(user != null) return user;
            else return null;
        }
        public User InsertUser([FromBody] RegisterRequest request)
        {
            try
            {
                var user = GetUserById(request.UserEmail);
                if(user == null)
                {
                    var newUser = new User
                    {
                        UserName = request.UserName,
                        UserEmail = request.UserEmail,
                        UserPassword = request.UserPassword,
                    };
                    _dbContext.User.Add(newUser);
                    _dbContext.SaveChanges();
                    return newUser;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public User GetUser([FromBody] LoginRequest request)
        {
            try
            {
                var user = (from u in _dbContext.User
                           where request.UserEmail == u.UserEmail && request.UserPassword == u.UserPassword
                           select u).FirstOrDefault();
                if (user != null) return user;
                else return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
