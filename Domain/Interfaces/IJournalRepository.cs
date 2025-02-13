using Domain.Entities;

namespace Domain.Interfaces;

public interface IJournalRepository
{
    Task<IEnumerable<JournalEntity>> GetJournals();
    Task<JournalEntity> GetJournalsByIdAsync(Guid id);
    Task<JournalEntity> AddJournalAsync(JournalEntity entity);
    Task<JournalEntity> UpdateJournalAsync(Guid journalId, JournalEntity entity);
    Task<bool> DeleteJournalAsync(Guid journalId);
}
