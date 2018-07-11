using Domain.Abstract;
using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{
   public class EFLadaRepository : ILadaRepository
    {
        EFDbContext context = new EFDbContext();
        public IEnumerable<Lada> Lada
        {
            get { return context.Lada; }
        }
        public void SaveLada(Lada game)
        {
            if (game.Id == 0)
                context.Lada.Add(game);
            else
            {
                Lada dbEntry = context.Lada.Find(game.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = game.Name;
                    dbEntry.Model = game.Model;
                    dbEntry.Price = game.Price;
                }
            }
            context.SaveChanges();
        }
        public Lada DeleteLada(int Id)
        {
            Lada dbEntry = context.Lada.Find(Id);
            if (dbEntry != null)
            {
                context.Lada.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
