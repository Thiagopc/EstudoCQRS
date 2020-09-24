using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace estudo.infra.Db.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        public Context _context {get;}

        public UnitOfWork(Context _context){
            this._context = _context;
        }

        public async Task Commit()
        {
            this._context.Database.CommitTransaction();
        }

        public async Task BeginTransaction()
        {
            await this._context.Database.BeginTransactionAsync();
        }

        public async Task Save()
        {
            await this._context.SaveChangesAsync();
        }
    }
}