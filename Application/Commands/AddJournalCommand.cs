using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands;

public record AddJournalCommand(JournalEntity Journal): IRequest<JournalEntity>;

public class AddJournalCommandHandler(IJournalRepository journalRepository) : IRequestHandler<AddJournalCommand, JournalEntity>
{
    public async Task<JournalEntity> Handle(AddJournalCommand request, CancellationToken cancellationToken)
    {
        return await journalRepository.AddJournalAsync(request.Journal);
    }
}
