using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Queries;

public record GetAllJournalsQuery() : IRequest<IEnumerable<JournalEntity>>;

public class GetAllJournalsQueryHandler(IJournalRepository journalRepository) : IRequestHandler<GetAllJournalsQuery, IEnumerable<JournalEntity>>
{
    public async Task<IEnumerable<JournalEntity>> Handle(GetAllJournalsQuery request, CancellationToken cancellationToken)
    {
        return await journalRepository.GetJournals();
    }
}
