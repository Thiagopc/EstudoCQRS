using System.Threading.Tasks;
using estudo.domain.Entity;

namespace estudo.domain.Interfaces.Repository
{
    public interface IRepositoryProduct
    {
        Task New(Product product);
        // Task Update(Product product);
        // Task Delete (int id);
        
    }
}