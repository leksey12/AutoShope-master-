using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
   public interface IPeugeotRepository
    {
        IEnumerable<Peugeot> Peugeot { get; }
        void SavePeugeot(Peugeot game);
        Peugeot DeletePeugeot(int Id);
    }
}
