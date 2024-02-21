using Application.Features.Brands.Queries.GetList;
using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries.GetById;
using Application.Features.Fuels.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Fuels.Profiles;

public class MappingProfiles : Profile
{
	public MappingProfiles()
	{
		CreateMap<Fuel, CreateFuelCommand>().ReverseMap();
		CreateMap<Fuel, CreatedFuelResponse>().ReverseMap();
		CreateMap<Fuel, DeletedFuelResponse>().ReverseMap();
		CreateMap<Fuel, UpdateFuelCommand>().ReverseMap();
		CreateMap<Fuel, UpdatedFuelReponse>().ReverseMap();
        CreateMap<Fuel, GetListFuelListItemDto>().ReverseMap();
        CreateMap<Paginate<Fuel>, GetListResponse<GetListFuelListItemDto>>().ReverseMap();
        CreateMap<Fuel, GetByIdFuelResponse>().ReverseMap();
    }
}
