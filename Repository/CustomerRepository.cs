using Microsoft.EntityFrameworkCore;
using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        BankContext db;
        public CustomerRepository(BankContext _db)
        {
            db = _db;
        }      

        public async Task<List<Customer>> GetCustomers()
        {
            if (db != null)
            {
                return await db.Customers.ToListAsync();
            }
            return null;
        }
    }
}
