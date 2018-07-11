using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
    public interface IAutoRepository
    {
        IEnumerable<Auto> Autos { get; }
    }
}
