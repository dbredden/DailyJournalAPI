using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands;

public record UpdateJournalCommand(Guid journalId, JournalEntity Journal) : IRequest<JournalEntity>;

public class UpdateJournalCommandHandler(IJournalRepository journalRepository) : IRequestHandler<UpdateJournalCommand, JournalEntity>
{
    public async Task<JournalEntity> Handle(UpdateJournalCommand request, CancellationToken cancellationToken)
    {
        return await journalRepository.UpdateJournalAsync(request.journalId, request.Journal);
    }
}
