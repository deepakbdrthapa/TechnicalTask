using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Repository
{
    public class BankRepository : IBankRepository
    {
        BankContext db;
        public BankRepository(BankContext _db)
        {
            db = _db;
        }      

        public async Task<List<Bank>> GetBanks()
        {
            if (db != null)
            {
                return await db.Banks.ToListAsync();
            }
            return null;
        }
    }
}
