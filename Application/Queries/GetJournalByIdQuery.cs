using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries;

public record GetJournalByIdQuery(Guid journalId) : IRequest<JournalEntity>;

public class GetJournalByIdHandler(IJournalRepository journalRepository) : IRequestHandler<GetJournalByIdQuery, JournalEntity>
{
    public async Task<JournalEntity> Handle(GetJournalByIdQuery request, CancellationToken cancellationToken)
    {
        return await journalRepository.GetJournalsByIdAsync(request.journalId);
    }
}
