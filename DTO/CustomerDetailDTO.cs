using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.DTO
{
    public class CustomerDetailDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AccountNumber { get; set; }
        public string MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

