using System.Threading.Tasks;
using estudo.domain.Entity;
using estudo.domain.Interfaces.Repository;
using estudo.infra.Db.Map;
using Microsoft.EntityFrameworkCore;

namespace estudo.infra.Db.Repository
{
    public  class RepositoryBase<Entity>:IRepositoryBase<Entity>
    where Entity: EntityBase
    {
        private IUnitOfWork _unitofwork;

        public RepositoryBase(IUnitOfWork unitofwork){
            this._unitofwork = unitofwork;
        }

        public Task Delete(Entity entity)
        {
            throw new System.NotImplementedException();
        }

        public async Task New(Entity entity){
            await this._unitofwork._context.Set<Entity>().AddAsync(entity);
           
            await this._unitofwork.Save();           
           
            // await this._repo.Database.BeginTransactionAsync();
            // await this._repo.Set<Entity>().AddAsync(entity);   
            // await this._repo.SaveChangesAsync();         
            // var outbox  = new Outbox(entity.GetType().Name,"New", entity);
            // await this._repo.Set<Outbox>().AddAsync(outbox);
            // await this._repo.SaveChangesAsync();
            // this._repo.Database.CommitTransaction();
        }

        public async Task Update(Entity entity){
            await this._unitofwork._context.AddAsync<Entity>(entity);
            this._unitofwork._context.Entry(entity).State = EntityState.Modified;
            // await this._repo.Database.BeginTransactionAsync();
            // this._repo.Entry(entity).State = EntityState.Modified;
            // await this._repo.Set<Entity>().AddAsync(entity);
            // var outbox  = new Outbox(entity.GetType().Name,"Update", entity);
            // await this._repo.Set<Outbox>().AddAsync(outbox);
            // await this._repo.SaveChangesAsync();
            // this._repo.Database.CommitTransaction();
        }
    }
}