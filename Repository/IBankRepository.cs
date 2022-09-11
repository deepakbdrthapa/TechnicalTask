using PaymentAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Repository
{
    public interface IBankRepository
    {
        Task<List<Bank>> GetBanks();
    }
}
