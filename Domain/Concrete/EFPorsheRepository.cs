using Domain.Abstract;
using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
   public class EFPorsheRepository : IPorsheRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Porshe> Porshe
        {
            get { return context.Porshe; }
        }
        public void SavePorshe(Porshe game)
        {
            if (game.Id == 0)
                context.Porshe.Add(game);
            else
            {
                Porshe dbEntry = context.Porshe.Find(game.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = game.Name;
                    dbEntry.Model = game.Model;
                    dbEntry.Price = game.Price;
                }
            }
            context.SaveChanges();
        }
        public Porshe DeletePorshe(int Id)
        {
            Porshe dbEntry = context.Porshe.Find(Id);
            if (dbEntry != null)
            {
                context.Porshe.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
