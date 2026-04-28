using Drkb.Documents.Application.UseCase.Command.Category.Create;
using Drkb.Documents.Application.UseCase.Command.Category.Delete;
using Drkb.Documents.Application.UseCase.Command.Category.Update;
using Drkb.Documents.Application.UseCase.Query.Category.GetAllCategoriesWithChildren;
using Drkb.Documents.Application.UseCase.Query.Category.GetCategoryWithChildrenById;
using Drkb.Documents.Application.UseCase.Query.Category.GetDocumentsByCategoryId;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Drkb.Documents.Controllers.Api;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Возвращает список категорий, доступных пользователю, вместе с дочерними категориями.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены операции.</param>
    /// <returns>Список категорий с иерархией дочерних категорий доступных пользователю.</returns>
    [HttpGet("tree")]
    public async Task<ActionResult<List<GetCategoriesTreeDto>>> GetCategoriesTree(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCategoriesTreeQuery(), cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }

        return StatusCode(result.StatusCode, result.ErrorMessage);
    }
    
    [HttpGet("{categoryId:guid}")]
    public async Task<ActionResult<GetCategoryDetailsDto>> GetCategoryDetails(Guid categoryId, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetCategoryDetailsQuery(categoryId), cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }

        return StatusCode(result.StatusCode, result.ErrorMessage);
    }

    [HttpGet("{categoryId:guid}/documents")]
    public async Task<ActionResult<List<GetDocumentsByCategoryIdDto>>> GetDocumentsByCategoryId(
        Guid categoryId,
        CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetDocumentsByCategoryIdQuery(categoryId), cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result.Data);
        }

        return StatusCode(result.StatusCode, result.ErrorMessage);
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok();
        }

        return StatusCode(result.StatusCode, result.ErrorMessage);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoryCommand command, CancellationToken cancellationToken)
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
        var result = await _mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
        if (result.IsSuccess)
        {
            return Ok();
        }

        return StatusCode(result.StatusCode, result.ErrorMessage);
    }
}
