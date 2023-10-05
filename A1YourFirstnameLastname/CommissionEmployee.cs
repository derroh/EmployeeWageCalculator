using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1YourFirstnameLastname
{
    public class CommissionEmployee : Employee
    {
        public decimal GrossSales { get; set; }
        public decimal CommissionRate { get; set; }

        public override decimal GrossEarnings => GrossSales * CommissionRate;
    }
}
