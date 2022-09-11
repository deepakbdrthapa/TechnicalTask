using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentAPI.Helpers
{
    public class AppSettings
    {
        public string Secret { get; set; } = "This is my supper secret key for jwt";
    }
}
