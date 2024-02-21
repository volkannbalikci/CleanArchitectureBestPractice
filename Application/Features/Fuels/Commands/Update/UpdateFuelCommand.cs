using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Commands.Update;

public class UpdateFuelCommand : IRequest<UpdatedFuelReponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, UpdatedFuelReponse>
    {
        private readonly IFuelRepository _fuelRepository;
        private readonly IMapper _mapper;

        public UpdateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
        {
            _fuelRepository = fuelRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedFuelReponse> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
        {
            Fuel fuel = await _fuelRepository.GetAsync(predicate: f => f.Id == request.Id, cancellationToken: cancellationToken);
            fuel = _mapper.Map(request, fuel);
            await _fuelRepository.UpdateAsync(fuel);
            UpdatedFuelReponse updatedFuelReponse = _mapper.Map<UpdatedFuelReponse>(fuel);
            return updatedFuelReponse;
        }
    }
}
