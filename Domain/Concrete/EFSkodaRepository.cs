using Domain.Abstract;
using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Concrete
{

    public class EFSkodaRepository : ISkodaRepository
    {
        EFDbContext context = new EFDbContext();
    public IEnumerable<Skoda> Skodas
        {
            get { return context.Skodas; }

        }
        public void SaveSkoda(Skoda game)
        {
            if (game.Id == 0)
                context.Skodas.Add(game);
            else
            {
                Skoda dbEntry = context.Skodas.Find(game.Id);
                if (dbEntry != null)
                {
                    dbEntry.Name = game.Name;
                    dbEntry.Model= game.Model;
                    dbEntry.Price = game.Price;
                }
            }
            context.SaveChanges();
        }
        public Skoda DeleteSkoda(int Id)
        {
            Skoda dbEntry = context.Skodas.Find(Id);
            if (dbEntry != null)
            {
                context.Skodas.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
     
       

