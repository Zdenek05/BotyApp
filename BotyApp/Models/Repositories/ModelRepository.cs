using Context = BotyApp.Context;
using System;
using Microsoft.EntityFrameworkCore;
using BotyApp.Models;

namespace BotyApp.Models.Repositories
{
    public class ModelRepository : IModelRepository
    {
        private Context.AppContext _dbContext;

        public ModelRepository(Context.AppContext dbContext)
        {
            _dbContext = dbContext;
        }




        public List<Model> FindAll()
        {
            return _dbContext.Model.ToList();
        }






        public Model? FindById(int id)
        {
            return _dbContext.Model.Where(g => g.Id == id).FirstOrDefault();
        }
    }
}
