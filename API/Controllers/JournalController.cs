using Application.Commands;
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


    }
}
