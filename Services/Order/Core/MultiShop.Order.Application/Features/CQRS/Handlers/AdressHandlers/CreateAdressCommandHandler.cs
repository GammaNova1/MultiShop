using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class CreateAdressCommandHandler
    {
        private readonly IRepository<Adress> _repositoriy;

        public CreateAdressCommandHandler(IRepository<Adress> repositoriy)
        {
            _repositoriy = repositoriy;
        }

        public async Task Handle(CreateAdressCommand createAdressCommand)
        {
            await _repositoriy.CreateAsync(new Adress
            {
                City = createAdressCommand.City,
                Detail = createAdressCommand.Detail,
                District = createAdressCommand.District,
                UserId = createAdressCommand.UserId
            });
        }
    }
}
