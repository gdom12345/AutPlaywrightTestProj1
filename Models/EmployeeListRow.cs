using System;
using System.Collections.Generic;
using System.Text;

namespace AutPlaywrightTestProj.Models
{
    public class EmployeeListRow
    {
        public string Name { get; set; }
        //Salary doesn't have decimals
        public long Salary { get; set; }
        public long DurationWorked { get; set; }
        public int Grade { get; set; }
        public string Email { get; set; }
    }
}
