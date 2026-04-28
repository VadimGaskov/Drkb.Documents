using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Category.GetDocumentsByCategoryId;

public class GetDocumentsByCategoryIdHandler : IRequestHandler<GetDocumentsByCategoryIdQuery, Result<List<GetDocumentsByCategoryIdDto>>>
{
    private readonly IGetDocumentsByCategoryId _getDocumentsByCategoryId;

    public GetDocumentsByCategoryIdHandler(IGetDocumentsByCategoryId getDocumentsByCategoryId)
    {
        _getDocumentsByCategoryId = getDocumentsByCategoryId;
    }

    public async Task<Result<List<GetDocumentsByCategoryIdDto>>> Handle(GetDocumentsByCategoryIdQuery request, CancellationToken cancellationToken)
    {
        var documents = await _getDocumentsByCategoryId.ExecuteAsync(request, cancellationToken);
        return Result<List<GetDocumentsByCategoryIdDto>>.Success(documents);
    }
}
