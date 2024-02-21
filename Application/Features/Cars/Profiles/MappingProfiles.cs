using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetList;
using Application.Features.Models.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Presistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Cars.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Car, CreateCarCommand>().ReverseMap();
        CreateMap<Car, CreatedCarResponse>().ReverseMap();
        CreateMap<Car, DeleteCarCommand>().ReverseMap();
        CreateMap<Car, DeletedCarResponse>().ReverseMap();
        CreateMap<Car, UpdateCarCommand>().ReverseMap();
        CreateMap<Car, UpdatedCarResponse>().ReverseMap();
        CreateMap<Car, GetListCarListItemDto>()
            .ForMember(destinationMember: c => c.ModelName, memberOptions: opt => opt.MapFrom(c => c.Model.Name))
            .ForMember(destinationMember: c => c.DailyPrice, memberOptions: opt => opt.MapFrom(c => c.Model.DailyPrice))
            .ForMember(destinationMember: c => c.ImageUrl, memberOptions: opt => opt.MapFrom(c => c.Model.ImageUrl));
        CreateMap<Car, GetByIdCarResponse>()
            .ForMember(destinationMember: c => c.ModelName, memberOptions: opt => opt.MapFrom(c => c.Model.Name))
            .ForMember(destinationMember: c => c.DailyPrice, memberOptions: opt => opt.MapFrom(c => c.Model.DailyPrice))
            .ForMember(destinationMember: c => c.ImageUrl, memberOptions: opt => opt.MapFrom(c => c.Model.ImageUrl));

        CreateMap<Car, Paginate<Car>>().ReverseMap();
        CreateMap<Car, GetListCarQuery>().ReverseMap();
        CreateMap<Paginate<Car>, GetListResponse<GetListCarListItemDto>>().ReverseMap();
        CreateMap<Car, GetByIdCarQuery>().ReverseMap();
        CreateMap<Car, GetByIdCarResponse>().ReverseMap();

    }
}
