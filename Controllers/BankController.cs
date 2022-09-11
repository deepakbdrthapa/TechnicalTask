using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentAPI.DTO;
using PaymentAPI.Models;
using PaymentAPI.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        public ICustomerRepository _customerRepository;
        public IBankRepository _bankRepository;
        public BankController(ICustomerRepository customerRepository, IBankRepository bankRepository)
        {

            this._customerRepository = customerRepository;
            this._bankRepository = bankRepository;
        }

        [HttpGet,Route("GetCustomerList")]
        [Authorize]
        public List<CustomerDetailDTO> GetCustomerList()
        {
            Task<List<Customer>> customerList = _customerRepository.GetCustomers();
            return customerList.Result.Select(x => new CustomerDetailDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                AccountNumber = x.AccountNumber,
                MobileNumber = x.MobileNumber,
                DateOfBirth = x.DateOfBirth
            }).ToList();
        }

        [HttpGet, Route("GetBankList")]
        [Authorize]
        public List<BankDetailDTO> GetBankList()
        {
            Task<List<Bank>> bankList = _bankRepository.GetBanks();
            return bankList.Result.Select(x => new BankDetailDTO
            {
                Id = x.Id,
                BankCode = x.BankCode,
                Branch = x.Branch,
                BankName = x.BankName
            }).ToList();
        }
    }
}
