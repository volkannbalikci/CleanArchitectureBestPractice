using Application.Features.Brands.Queries.GetList;
using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.Delete;
using Application.Features.Transmissions.Commands.Update;
using Application.Features.Transmissions.Queries.GetById;
using Application.Features.Transmissions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Transmissions.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Transmission, CreateTransmissionCommand>().ReverseMap();
		CreateMap<Transmission, CreatedTransmissionResponse>().ReverseMap();
		CreateMap<Transmission, DeletedTransmissionResponse>().ReverseMap();
		CreateMap<Transmission, DeleteTransmissionCommand>().ReverseMap();
		CreateMap<Transmission, UpdateTransmissionCommand>().ReverseMap();
		CreateMap<Transmission, UpdatedTransmissionResponse>().ReverseMap();
		CreateMap<Paginate<Transmission>, GetListResponse<GetListTransmissionListItemDto>>().ReverseMap();
		CreateMap<Transmission, GetListTransmissionListItemDto>().ReverseMap();
		CreateMap<Transmission, GetByIdTransmissionQuery>().ReverseMap();
		CreateMap<Transmission, GetByIdTransmissionResponse>().ReverseMap();
	}
}
