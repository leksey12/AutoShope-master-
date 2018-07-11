using Domain.Abstract;
using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
   public class EFPeugeotRepository : IPeugeotRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Peugeot> Peugeot
        {
            get { return context.Peugeot; }
        }
        public void SavePeugeot(Peugeot game)
        {
            if (game.Id == 0)
                context.Peugeot.Add(game);
            else
            {
                Peugeot dbEntry = context.Peugeot.Find(game.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = game.Name;
                    dbEntry.Model = game.Model;
                    dbEntry.Price = game.Price;
                }
            }
            context.SaveChanges();
        }
        public Peugeot DeletePeugeot(int Id)
        {
            Peugeot dbEntry = context.Peugeot.Find(Id);
            if (dbEntry != null)
            {
                context.Peugeot.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
