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
    public class UpdateAdressCommandHandler
    {
        private readonly IRepository<Adress> _repository;

        public UpdateAdressCommandHandler(IRepository<Adress> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateAdressCommand command)
        {
            var values = await _repository.GetByIdAsync(command.AdressId);
            values.UserId = command.UserId;
            values.Detail = command.Detail;
            values.District = command.District;
            values.City = command.City;
            await _repository.UpdateAsync(values);
        }
    }
}
