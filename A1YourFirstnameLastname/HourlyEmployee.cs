using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A1YourFirstnameLastname
{
    public class HourlyEmployee : Employee
    {
        public decimal HoursWorked { get; set; }
        public decimal HourlyWage { get; set; }

        public override decimal GrossEarnings
        {
            get
            {
                return HoursWorked <= 40 ? HourlyWage * HoursWorked :
                    40 * HourlyWage + (HoursWorked - 40) * HourlyWage * 1.5m;
            }
        }
    }
}
