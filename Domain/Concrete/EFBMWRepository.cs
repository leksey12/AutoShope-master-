using Domain.Abstract;
using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
   public class EFBMWRepository : IBMWRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<BMW> BMWs
        {
            get { return context.BMWs; }
        }
        public void SaveBMW(BMW game)
        {
            if (game.Id == 0)
                context.BMWs.Add(game);
            else
            {
                BMW dbEntry = context.BMWs.Find(game.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = game.Name;
                    dbEntry.Model = game.Model;
                    dbEntry.Price = game.Price;
                }
            }
            context.SaveChanges();
        }
        public BMW DeleteBMW(int Id)
        {
            BMW dbEntry = context.BMWs.Find(Id);
            if (dbEntry != null)
            {
                context.BMWs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
