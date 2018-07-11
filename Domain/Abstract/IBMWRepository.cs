using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstract
{
   public interface IBMWRepository
    {
        IEnumerable<BMW> BMWs { get; }
        void SaveBMW(BMW game);
        BMW DeleteBMW(int Id);
    }
}
