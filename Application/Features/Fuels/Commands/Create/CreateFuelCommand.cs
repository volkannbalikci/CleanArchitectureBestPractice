using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Commands.Create
{
    public class CreateFuelCommand : IRequest<CreatedFuelResponse>
    {
        public string Name { get; set; }

        public class CreateFuelCommandHandler : IRequestHandler<CreateFuelCommand, CreatedFuelResponse>
        {
            private readonly IFuelRepository _fuelRepository;
            private readonly IMapper _mapper;

            public CreateFuelCommandHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                _fuelRepository = fuelRepository;
                _mapper = mapper;
            }

            public async Task<CreatedFuelResponse> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
            {
                Fuel fuel = _mapper.Map<Fuel>(request);
                fuel.Id = Guid.NewGuid();
                var result = await _fuelRepository.AddAsync(fuel);
                CreatedFuelResponse createdFuelResponse = _mapper.Map<CreatedFuelResponse>(result);
                return createdFuelResponse;
            }
        }
    }
}
