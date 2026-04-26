using Drkb.Documents.Application.UseCase.Command.Tag.Create;
using Drkb.Documents.Application.UseCase.Command.Tag.Delete;
using Drkb.Documents.Application.UseCase.Command.Tag.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Drkb.Documents.Controllers.Api;

[ApiController]
[Route("api/tags")]
public class TagsController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTagCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok();
        }

        return StatusCode(result.StatusCode, result.ErrorMessage);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id,[FromBody] UpdateTagCommand command, CancellationToken cancellationToken)
    {
        if (id != command.Id)
            return BadRequest();
        
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok();
        }

        return StatusCode(result.StatusCode, result.ErrorMessage);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteTagCommand(id), cancellationToken);
        if (result.IsSuccess)
        {
            return Ok();
        }

        return StatusCode(result.StatusCode, result.ErrorMessage);
    }
}
