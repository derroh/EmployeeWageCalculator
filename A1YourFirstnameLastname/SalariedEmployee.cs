using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1YourFirstnameLastname
{
    public class SalariedEmployee : Employee
    {
        public decimal WeeklySalary { get; set; }

        public override decimal GrossEarnings => WeeklySalary;
    }
}
