using RESTWithASP_NET5.Data.VO;
using RESTWithASP_NET5.Models;
using RESTWithASP_NET5.Models.Context;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace RESTWithASP_NET5.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly MySQLContext _context;
        public UserRepository(MySQLContext context)
        {
            _context = context;
        }

        public User ValidateCredentials(UserVO user)
        {
            var pass = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            return _context.Users.FirstOrDefault(u => (u.UserName == user.UserName) && (u.Password == pass));
        }

        private string ComputeHash(string input, SHA256CryptoServiceProvider algorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        public User RefreshUserInfo(User user)
        {
            if (!_context.Users.Any(u => u.Id.Equals(user.Id)))
                return null;

            var result = _context.Users.SingleOrDefault(p => p.Id.Equals(user.Id));

            if (result == null)
                return null;

            try
            {
                _context.Entry(result).CurrentValues.SetValues(user);
                _context.SaveChanges();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
