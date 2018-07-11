using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
   public interface ILadaRepository
    {
        IEnumerable<Lada> Lada { get; }
        void SaveLada(Lada game);
        Lada DeleteLada(int Id);
    }
}
