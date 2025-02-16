using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Commands;

public record DeleteJournalCommand(Guid journalId) : IRequest<bool>;

public class DeleteJournalCommandHandler(IJournalRepository journalRepository) : IRequestHandler<DeleteJournalCommand, bool>
{
    public async Task<bool> Handle(DeleteJournalCommand request, CancellationToken cancellationToken)
    {
        return await journalRepository.DeleteJournalAsync(request.journalId);
    }
}
