using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalDevelopment.Interfaces
{
    public interface IYear
    {
        void Year();
        string Name { get; set; }
        List<IMonth> Months { get; set; }
        bool Equals(IYear other);
    }
}
