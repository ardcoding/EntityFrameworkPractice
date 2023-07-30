using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework_Practice.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int Salary { get; set; }
        public ICollection<ProjectEmployee> Projects { get; set; }
    }
}
