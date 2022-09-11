using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PaymentAPI.Helpers;
using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PaymentAPI.Repository
{
    public class UserRepository : IUserRepository
    {       

        BankContext db;
        private readonly AppSettings appSettings;
        public UserRepository(BankContext _db, IOptions<AppSettings> _appSettings)
        {
            db = _db;
            appSettings = _appSettings.Value;
        }           
                   

        public string  GenerateToken(UserLogin user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.UTF8.GetBytes(appSettings.Secret);

            var claims = new List<Claim>
            {
              new Claim("userName", user.UserName)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<User> GetUser(string userName, string password)
        {
            if (db != null)
            {
                return await db.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefaultAsync();
            }
            return null;
        }      
    }
}
