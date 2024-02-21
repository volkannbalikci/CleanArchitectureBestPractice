using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.Create
{
    public class CreateTransmissionCommand : IRequest<CreatedTransmissionResponse>
    {
        public string Name { get; set; }

        public class CreateTransmissionCommandHandler : IRequestHandler<CreateTransmissionCommand, CreatedTransmissionResponse>
        {
            public ITransmissionRepository _transmissionRepository{ get; set; }
            public IMapper _mapper{ get; set; }

            public CreateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
            {
                _transmissionRepository = transmissionRepository;
                _mapper = mapper;
            }

            public async Task<CreatedTransmissionResponse> Handle(CreateTransmissionCommand request, CancellationToken cancellationToken)
            {
                Transmission transmission = _mapper.Map<Transmission>(request);

                transmission.Id = Guid.NewGuid();

                var result = await _transmissionRepository.AddAsync(transmission);
                
                CreatedTransmissionResponse createdTransmissionResponse = _mapper.Map<CreatedTransmissionResponse>(result);

                return createdTransmissionResponse;
            }
        }
    }
}
