using System;
using System.Threading.Tasks;
using estudo.domain.Command;
using estudo.domain.Entity;
using estudo.domain.Interfaces.Repository;
using estudo.infra.Db.Map;
using estudo.infra.Db.Repository;
using estudo.infra.Query;
using Microsoft.AspNetCore.Mvc;

namespace estudo.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {

        private IUnitOfWork _unit;
        private QueryMongo _query;
        private ProductCommandHandler _commandHandler;
        public ProductController(ProductCommandHandler commandHandler,
        QueryMongo query,
        IUnitOfWork _uni)
        {
            this._commandHandler = commandHandler;
             this._query = query;
             this._unit = _uni;
        }

        [HttpPost]
        public async Task<IActionResult> Save([FromBody] RegisterProductCommand command)
        {

            await this._unit.BeginTransaction();
            var x = Guid.NewGuid();
            Console.WriteLine(x.ToString());
            command = new RegisterProductCommand(){
                Description = "Texte",
                Name = "XX",
                Price = 10,
                Id = x

            };
            await this._commandHandler.Handle(command);
            await this._unit.Commit();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateProductCommand command)
        {
            await this._commandHandler.Handle(command);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await this._commandHandler.Handle(new DeleteProductCommand() { Id = id });
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            return Ok(await this._query.List());
        }

    }
}