using Context = BotyApp.Context;
using Microsoft.EntityFrameworkCore;
using System;
using BotyApp.Models;

namespace BotyApp.Models.Repositories
{
    public class SneakerRepository : ISneakerRepository
    {
        private Context.AppContext _dbContext;

        public SneakerRepository(Context.AppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Sneaker> FindAll()
        {
            return _dbContext.Sneakers.Include(m => m.Model).ToList();
        }

        public Sneaker FindById(int id)
        {
            return _dbContext.Sneakers.Where(m => m.Id == id).FirstOrDefault();
        }



        public bool AddSneaker(string brand, Model model, string size, string photoPath)
        {
            _dbContext.Sneakers.Add(new Sneaker()
            {
                Model = model,
                Brand = brand,
                Size = size,
                Photo = photoPath,
            });

            if (_dbContext.SaveChanges() == 1)
            {
                return true;
            }

            return false;
        }
        public bool DeleteSneaker(Sneaker sneaker)
        {
            _dbContext.Remove(sneaker);

            _dbContext.SaveChanges();

            return true;
        }



        public bool UpdateSneaker(Sneaker sneaker)
        {
            _dbContext.Update(sneaker);
            _dbContext.SaveChanges();
            return true;
        }

    }
}
