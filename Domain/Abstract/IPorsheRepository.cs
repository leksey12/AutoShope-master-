using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
   public interface IPorsheRepository
    {
        IEnumerable<Porshe> Porshe { get; }
        void SavePorshe(Porshe game);
        Porshe DeletePorshe(int Id);
    }
}
