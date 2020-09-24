using System.Threading.Tasks;
using estudo.domain.Entity;

namespace estudo.domain.Interfaces.Repository
{
    public interface IRepositoryBase<Entity> where Entity: EntityBase 
    {
         Task New(Entity entity);
         Task Update(Entity entity);
         Task Delete(Entity entity);
         
    }
}