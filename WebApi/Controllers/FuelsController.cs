using Application.Features.Brands.Commands.Delete;
using Application.Features.Brands.Commands.Update;
using Application.Features.Brands.Queries.GetList;
using Application.Features.Fuels.Commands.Create;
using Application.Features.Fuels.Commands.Delete;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Fuels.Queries.GetById;
using Application.Features.Fuels.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateFuelCommand createFuelCommand)
        {
            CreatedFuelResponse createdFuelResponse = await Mediator.Send(createFuelCommand);
            return Ok(createdFuelResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFuelCommand updateFuelCommand)
        {
            UpdatedFuelReponse updatedFuelResponse = await Mediator.Send(updateFuelCommand);
            return Ok(updatedFuelResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteFuelCommand deleteFuelCommand = new() { Id = id };
            DeletedFuelResponse deletedFuelResponse = await Mediator.Send(deleteFuelCommand);
            return Ok(deletedFuelResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListFuelQuery getListFuelQuery = new() { PageRequest = pageRequest };

            GetListResponse<GetListFuelListItemDto> response = await Mediator.Send(getListFuelQuery);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdFuelQuery getByIdFuelQuery = new() { Id = id };
            GetByIdFuelResponse getByIdFuelResponse = await Mediator.Send(getByIdFuelQuery);
            return Ok(getByIdFuelResponse);
        }
    }
}
