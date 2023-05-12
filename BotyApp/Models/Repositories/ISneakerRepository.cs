using BotyApp.Models;

namespace BotyApp.Models.Repositories
{
    public interface ISneakerRepository
    {
        Sneaker? FindById(int id);
        List<Sneaker> FindAll();

        bool UpdateSneaker(Sneaker sneaker);

        bool DeleteSneaker(Sneaker sneaker);
        bool AddSneaker(string brand, Model model, string size, string photoPath);
    }
}