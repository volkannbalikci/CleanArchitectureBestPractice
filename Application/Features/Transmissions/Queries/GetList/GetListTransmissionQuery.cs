using Application.Features.Brands.Queries.GetList;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Queries.GetList;

public class GetListTransmissionQuery : IRequest<GetListResponse<GetListTransmissionListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListTransmissionCommandHandler : IRequestHandler<GetListTransmissionQuery, GetListResponse<GetListTransmissionListItemDto>>
    {
        private readonly ITransmissionRepository _tranmissionRepository;
        private readonly IMapper _mapper;

        public GetListTransmissionCommandHandler(ITransmissionRepository tranmissionRepository, IMapper mapper)
        {
            _tranmissionRepository = tranmissionRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListTransmissionListItemDto>> Handle(GetListTransmissionQuery request, CancellationToken cancellationToken)
        {
            Paginate<Transmission> tranmissions = await _tranmissionRepository.GetListAsync(
                index: request.PageRequest.PageIndex,
                size: request.PageRequest.PageSize,
                cancellationToken: cancellationToken
               );

            GetListResponse<GetListTransmissionListItemDto> response = _mapper.Map<GetListResponse<GetListTransmissionListItemDto>>(tranmissions);
            return response;
        }
    }
}
