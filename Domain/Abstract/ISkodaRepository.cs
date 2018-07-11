using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
   public interface ISkodaRepository
    {
        IEnumerable<Skoda> Skodas { get; }
        void SaveSkoda(Skoda game);
        Skoda DeleteSkoda(int Id);

    }
}
