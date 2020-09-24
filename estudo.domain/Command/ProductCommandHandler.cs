using System.Threading.Tasks;
using estudo.domain.Entity;
using estudo.domain.Interfaces.Repository;

namespace estudo.domain.Command
{
    public class ProductCommandHandler
    {
        // private IRepositoryProduct _repo;
        IRepositoryBase<Product> _repoProduct;
        IRepositoryBase<Outbox>  _repoOutbox;
        
        

        public ProductCommandHandler(IRepositoryBase<Product> repositoryproduct,
        IRepositoryBase<Outbox> repositoryoutobox){
            this._repoProduct = repositoryproduct;
            this._repoOutbox = repositoryoutobox;
        }


         public async Task Handle(RegisterProductCommand command){
            var product  = new Product(command.Id, command.Name, command.Description, command.Price);
            await this._repoProduct.New(product);
            await this._repoOutbox.New(new Outbox(product.GetType().Name, "New", product));
        }

        public async Task Handle(UpdateProductCommand command){
            var product  = new Product(command.Id, command.Name, command.Description, command.Price);
            await this._repoProduct.Update(product);
            await this._repoOutbox.New(new Outbox(product.GetType().Name,"Update",product));
        }

        public async Task Handle(DeleteProductCommand command){
            var product  = new Product(command.Id, command.Name, command.Description, command.Price);
            await this._repoProduct.Update(product);
            await this._repoOutbox.New(new Outbox(product.GetType().Name,"Delete",product));
        }


    }
}