using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public interface ICRUD
    {
        Task Create();
        Task DeleteProject(int id);
        Task DeleteEmployee(int id);
    }
}
