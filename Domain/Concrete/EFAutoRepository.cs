using Domain.Abstract;
using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
   public class EFAutoRepository : IAutoRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Auto> Autos
        {
            get { return context.Autos; }
        }
       
    }
}
