using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AdressQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdressesController : ControllerBase
    {
        private readonly GetAdressQueryHandler _getAdressQueryHandler;
        private readonly GetAdressByIdQueryHandler _getAdressByIdQueryHandler;
        private readonly CreateAdressCommandHandler _createAdressCommandHandler;
        private readonly UpdateAdressCommandHandler _updateAdressCommandHandler;
        private readonly RemoveAdressCommandHandler _removeAdressCommandHandler;

        public AdressesController(GetAdressQueryHandler getAdressQueryHandler, GetAdressByIdQueryHandler getAdressByIdQueryHandler, CreateAdressCommandHandler createAdressCommandHandler, UpdateAdressCommandHandler updateAdressCommandHandler, RemoveAdressCommandHandler removeAdressCommandHandler)
        {
            _getAdressQueryHandler = getAdressQueryHandler;
            _getAdressByIdQueryHandler = getAdressByIdQueryHandler;
            _createAdressCommandHandler = createAdressCommandHandler;
            _updateAdressCommandHandler = updateAdressCommandHandler;
            _removeAdressCommandHandler = removeAdressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AdressesList()
        {
            var values =await _getAdressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetAdressById(int id)
        {
            var values =await  _getAdressByIdQueryHandler.Handle(new GetAdressByIdQuery(id));
            return Ok(values);
        }
        public async Task<IActionResult> CreateAdress(CreateAdressCommand command)
        {
            await _createAdressCommandHandler.Handle(command);
            return Ok("Adres bilgisi başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdress(UpdateAdressCommand command)
        {
            await _updateAdressCommandHandler.Handle(command);
            return Ok("Adres bilgisi başarıyla güncellendi");
        }
        [HttpDelete]
        public async Task<IActionResult>RemoveAdress(int id) 
        {
            await _removeAdressCommandHandler.Handle(new RemoveAdressCommand(id));
            return Ok("Adres Bilgisi başarıyla silindi");
        }
    }
}
