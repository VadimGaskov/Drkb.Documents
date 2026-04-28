using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Document.GetFavoriteDocuments;

public class GetFavoriteDocumentsHandler : IRequestHandler<GetFavoriteDocumentsQuery, Result<List<GetFavoriteDocumentsDto>>>
{
    private readonly IGetFavoriteDocuments _getFavoriteDocuments;

    public GetFavoriteDocumentsHandler(IGetFavoriteDocuments getFavoriteDocuments)
    {
        _getFavoriteDocuments = getFavoriteDocuments;
    }

    public async Task<Result<List<GetFavoriteDocumentsDto>>> Handle(GetFavoriteDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await _getFavoriteDocuments.ExecuteAsync(request, cancellationToken);
        
        return Result<List<GetFavoriteDocumentsDto>>.Success(documents);
    }
}
