using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class JournalRepository(AppDbContext dbContext) : IJournalRepository
{
    public async Task<IEnumerable<JournalEntity>> GetJournals()
    {
        return await dbContext.Journals.ToListAsync();
    }

    public async Task<JournalEntity> GetJournalsByIdAsync(Guid id)
    {
        return await dbContext.Journals.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<JournalEntity> AddJournalAsync(JournalEntity entity)
    {
        entity.Id = Guid.NewGuid();
        dbContext.Journals.Add(entity);

        await dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<JournalEntity> UpdateJournalAsync(Guid journalId, JournalEntity entity)
    {
        var journal = await dbContext.Journals.FirstOrDefaultAsync(x => x.Id == journalId);

        if (journal is not null)
        {
            journal.Title = entity.Title;
            journal.Author = entity.Author;
            journal.Body = entity.Body;

            await dbContext.SaveChangesAsync();

            return journal;
        }

        return entity;
    }

    public async Task<bool> DeleteJournalAsync(Guid journalId)
    {
        var journal = await dbContext.Journals.FirstOrDefaultAsync(x => x.Id == journalId);

        if (journal is not null)
        {
            dbContext.Journals.Remove(journal);

            return await dbContext.SaveChangesAsync() > 0;
        }

        return false;
    }
}
