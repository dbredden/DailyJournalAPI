using Application.Commands;
using Application.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JournalController(ISender sender) : ControllerBase
    {
        [HttpPost("")]
        public async Task<IActionResult> AddJournalAsync([FromBody] JournalEntity journal)
        {
            var result = await sender.Send(new AddJournalCommand(journal));
            return Ok(result);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAllJournalsAsync()
        {
            var result = await sender.Send(new GetAllJournalsQuery());
            return Ok(result);
        }

        [HttpGet("{journalId}")]
        public async Task<IActionResult> GetJournalByIdAsync([FromRoute] Guid journalId)
        {
            var result = await sender.Send(new GetJournalByIdQuery(journalId));
            return Ok(result);
            // add try catch and include a Not found response
        }

        [HttpPut("{journalId}")]
        public async Task<IActionResult> UpdateJournalAsync([FromRoute] Guid journalId, [FromBody] JournalEntity journal)
        {
            var result = await sender.Send(new UpdateJournalCommand(journalId, journal));
            return Ok(result);
        }

        [HttpDelete("{journalId}")]
        public async Task<IActionResult> DeleteJournalsAsync([FromRoute] Guid journalId, [FromBody] JournalEntity journal)
        {
            var result = await sender.Send(new DeleteJournalCommand(journalId));
            return Ok(result);
        }
    }
}
