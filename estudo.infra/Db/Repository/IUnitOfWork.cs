using System.Threading.Tasks;

namespace estudo.infra.Db.Repository
{
         public interface IUnitOfWork
    {
         Context _context {get;}
         Task BeginTransaction();
         Task Save();
         Task Commit();

    }
}