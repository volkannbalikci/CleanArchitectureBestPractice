using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Commands.Update;

public class UpdateTransmissionCommand : IRequest<UpdatedTransmissionResponse>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public class UpdateTransmissionCommandHandler : IRequestHandler<UpdateTransmissionCommand, UpdatedTransmissionResponse>
    {
        private readonly ITransmissionRepository _transmissionRepository;
        private readonly IMapper _mapper;

        public UpdateTransmissionCommandHandler(ITransmissionRepository transmissionRepository, IMapper mapper)
        {
            _transmissionRepository = transmissionRepository;
            _mapper = mapper;
        }

        public async Task<UpdatedTransmissionResponse> Handle(UpdateTransmissionCommand request, CancellationToken cancellationToken)
        {
            Transmission transmission = await _transmissionRepository.GetAsync(predicate: t => t.Id == request.Id);
            transmission = _mapper.Map<Transmission>(request);
            await _transmissionRepository.UpdateAsync(transmission);
            UpdatedTransmissionResponse updatedTransmissionResponse = _mapper.Map<UpdatedTransmissionResponse>(transmission);
            return updatedTransmissionResponse;
        }
    }
}
