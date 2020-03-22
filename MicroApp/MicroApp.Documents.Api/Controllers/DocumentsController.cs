using MicroApp.Common.Dispatcher;
using MicroApp.Documents.Api.Dto;
using MicroApp.Documents.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MicroApp.Documents.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : BaseController
    {
        public DocumentsController(IDispatcher dispatcher) : base(dispatcher)
        {
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentDto>> GetAsync([FromRoute] GetDocument query)
            => Single(await QueryAsync(query));
    }
}