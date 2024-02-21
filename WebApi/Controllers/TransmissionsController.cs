using Application.Features.Brands.Commands.Update;
using Application.Features.Fuels.Commands.Update;
using Application.Features.Transmissions.Commands.Create;
using Application.Features.Transmissions.Commands.Delete;
using Application.Features.Transmissions.Commands.Update;
using Application.Features.Transmissions.Queries.GetById;
using Application.Features.Transmissions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTransmissionCommand createTransmissionCommand)
        {
            CreatedTransmissionResponse createdTransmissionResponse = await Mediator.Send(createTransmissionCommand);

            return Ok(createdTransmissionResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTransmissionCommand updateTransmissionCommand)
        {
            UpdatedTransmissionResponse updatedTransmissionResponse = await Mediator.Send(updateTransmissionCommand);
            return Ok(updatedTransmissionResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteTransmissionCommand deleteTransmissionCommand = new() { Id = id };
            DeletedTransmissionResponse deletedTransmissionResponse = await Mediator.Send(deleteTransmissionCommand);
            return Ok(deletedTransmissionResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTransmissionQuery getListTransmissionQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListTransmissionListItemDto> response = await Mediator.Send(getListTransmissionQuery);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdTransmissionQuery getByIdTransmissionQuery = new() { Id=id };
            GetByIdTransmissionResponse getByIdTransmissionResponse = await Mediator.Send(getByIdTransmissionQuery);
            return Ok(getByIdTransmissionResponse);
        }

    }
}
