using BotyApp.Models;

namespace BotyApp.Models.Repositories
{
    public interface IModelRepository
    {
        List<Model> FindAll();


        Model? FindById(int id);
    }
}
