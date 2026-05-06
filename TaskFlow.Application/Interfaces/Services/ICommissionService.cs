using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.Interfaces.Services
{
    public interface ICommissionService
    {
        public decimal GetRate(string category);
    }
}
