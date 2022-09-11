using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Models
{
    public class Bank
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string  BankCode { get; set; }
        public string Branch { get; set; }
    }
}
