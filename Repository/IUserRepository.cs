using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Repository
{
    public interface IUserRepository
    {
        public Task<User> GetUser(string userName, string password);
        public string GenerateToken(UserLogin user);
    }
}
