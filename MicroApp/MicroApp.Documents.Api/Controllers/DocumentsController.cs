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

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult<DocumentDto>> GetById([FromRoute] GetDocumentById query)
            => Single(await QueryAsync(query));

        [HttpGet("GetByExternalId/{id}")]
        public async Task<ActionResult<DocumentDto>> GetByExternalId([FromRoute] GetDocumentByExternalId query)
            => Single(await QueryAsync(query));

        [HttpGet("GetAllDocumentsByExternalId")]
        public async Task<ActionResult<DocumentDto[]>> GetAllDocumentsByExternalId([FromQuery] BrowseDocumentsByExternalId query)
            => await QueryAsync(query);
    }
}