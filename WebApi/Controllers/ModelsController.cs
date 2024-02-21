using Application.Features.Models.Commands.Create;
using Application.Features.Models.Commands.Delete;
using Application.Features.Models.Commands.Update;
using Application.Features.Models.Queries.GetById;
using Application.Features.Models.Queries.GetList;
using Application.Features.Models.Queries.GetListByDynamic;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Presistence.Dynamic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateModelCommand createModelCommand)
        {
            CreatedModelResponse createdModelResponse = await Mediator.Send(createModelCommand);
            return Ok(createdModelResponse);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateModelCommand updateModelCommand)
        {
            UpdatedModelResponse updatedModelResponse = await Mediator.Send(updateModelCommand);
            return Ok(updatedModelResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeleteModelCommand deleteModelCommand = new() { Id = id };
            DeletedModelResponse deletedModelResponse = await Mediator.Send(deleteModelCommand);
            return Ok(deletedModelResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListModelQuery getListModelQuery = new GetListModelQuery { PageRequest = pageRequest };
            GetListResponse<GetListModelListItemDto> response = await Mediator.Send(getListModelQuery);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdModelQuery getByIdModelQuery = new() { Id = id };
            GetByIdModelResponse getByIdModelResponse = await Mediator.Send(getByIdModelQuery);
            return Ok(getByIdModelResponse);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery=null)
        {
            GetListByDynamicModelQuery getListByDynamicModelQuery = new GetListByDynamicModelQuery { PageRequest = pageRequest, DynamicQuery = dynamicQuery };
            GetListResponse<GetListByDynamicModelListItemDto> response = await Mediator.Send(getListByDynamicModelQuery);
            return Ok(response);
        }
    }
}
