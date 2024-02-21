using Application.Features.Cars.Commands.Create;
using Application.Features.Cars.Commands.Delete;
using Application.Features.Cars.Commands.Update;
using Application.Features.Cars.Queries.GetById;
using Application.Features.Cars.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCarCommand createCarCommand)
        {
            CreatedCarResponse createdCarResponse = await Mediator.Send(createCarCommand);
            return Ok(createdCarResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCarCommand updateCarCommand)
        {
            UpdatedCarResponse updatedCarResponse = await Mediator.Send(updateCarCommand);
            return Ok(updatedCarResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteCarCommand deleteCarCommand = new() { Id = id };
            DeletedCarResponse deletedCarResponse = await Mediator.Send(deleteCarCommand);
            return Ok(deletedCarResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListCarQuery getListCarQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListCarListItemDto> getListResponse = await Mediator.Send(getListCarQuery);
            return Ok(getListResponse);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdCarQuery getByIdCarQuery = new() { Id = id };
            GetByIdCarResponse getByIdCarResponse = await Mediator.Send(getByIdCarQuery);
            return Ok(getByIdCarResponse);
        }
    }
}
