using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Commands.Create
{
    public class CreateModelCommand : IRequest<CreatedModelResponse>
    {
        public Guid BrandId { get; set; }
        public Guid FuelId { get; set; }
        public Guid TransmissionId { get; set; }
        public string Name { get; set; }
        public decimal DailyPrice { get; set; }
        public string ImageUrl { get; set; }

        public class CreateModelCommandHandler : IRequestHandler<CreateModelCommand, CreatedModelResponse>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public CreateModelCommandHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<CreatedModelResponse> Handle(CreateModelCommand request, CancellationToken cancellationToken)
            {
                Model model = _mapper.Map<Model>(request);

                model.Id = Guid.NewGuid();

                var result  = await _modelRepository.AddAsync(model);

                CreatedModelResponse createdModelResponse = _mapper.Map<CreatedModelResponse>(result);

                return createdModelResponse;
            }
        }

    }
}
