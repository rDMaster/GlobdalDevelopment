using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IMonth
    {
        void AddUniquePage<IPage>(IPage item);
        string Name { get; set; }
        List<IPage> Pages { get; set; }
        List<IDay> Days { get; set; }
        bool Equals(IMonth other);
    }
}
