using Drkb.ResultObjects;
using MediatR;

namespace Drkb.Documents.Application.UseCase.Query.Document.GetAllByUserDocuments;

public class GetFavoriteDocumentsHandler : IRequestHandler<GetFavoriteDocumentsQuery, Result<List<GetFavoriteDocumentsDto>>>
{
    private readonly GetFavoriteDocuments _getFavoriteDocuments;

    public GetFavoriteDocumentsHandler(GetFavoriteDocuments getFavoriteDocuments)
    {
        _getFavoriteDocuments = getFavoriteDocuments;
    }

    public async Task<Result<List<GetFavoriteDocumentsDto>>> Handle(GetFavoriteDocumentsQuery request, CancellationToken cancellationToken)
    {
        var documents = await _getFavoriteDocuments.ExecuteAsync(request, cancellationToken);
        
        return Result<List<GetFavoriteDocumentsDto>>.Success(documents);
    }
}
