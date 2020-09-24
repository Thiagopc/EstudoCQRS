using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using estudo.service.Model;
using Microsoft.EntityFrameworkCore;

namespace estudo.service.Repository
{
    public class RepositoryOutbox
    {
        private Context _repo;

        public RepositoryOutbox(){
            this._repo = new Context();
        }

        public async Task<List<OutBox>> List(){            ;
            return await this._repo.OutBox.ToListAsync();
        }

        public async Task Remove(OutBox outbox){
             this._repo.OutBox.Remove(outbox);
             await this._repo.SaveChangesAsync();
        }
    }
}