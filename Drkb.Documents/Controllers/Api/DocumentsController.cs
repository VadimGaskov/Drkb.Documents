using Drkb.Documents.Application.UseCase.Command.Document.AssignTags;
using Drkb.Documents.Application.UseCase.Command.Document.Create;
using Drkb.Documents.Application.UseCase.Command.Document.Delete;
using Drkb.Documents.Application.UseCase.Command.Document.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Drkb.Documents.Controllers.Api;

[ApiController]
[Route("api/documents")]
public class DocumentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public DocumentsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateDocumentCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok();
        }

        return StatusCode(result.StatusCode, result.ErrorMessage);
    }

    [HttpPut("{doocumentId:guid}/tags")]
    public async Task<IActionResult> AssignTags(Guid documentId, [FromBody] AssignTagsCommand command, CancellationToken cancellationToken)
    {
        if (documentId != command.DocumentId)
            return BadRequest();

        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsSuccess)
            return Ok();

        return StatusCode(result.StatusCode, result.ErrorMessage);
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id,[FromBody] UpdateDocumentCommand command, CancellationToken cancellationToken)
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
        var result = await _mediator.Send(new DeleteDocumentCommand(id), cancellationToken);
        if (result.IsSuccess)
        {
            return Ok();
        }

        return StatusCode(result.StatusCode, result.ErrorMessage);
    }
}
