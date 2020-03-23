using MicroApp.Api.Messages.Commands.Documents;
using MicroApp.Api.Services;
using MicroApp.Common.Mvc;
using MicroApp.Common.RabbitMq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenTracing;
using System;
using System.IO;
using System.Threading.Tasks;

namespace MicroApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : BaseController
    {
        private readonly IDocumentsService _documentsService;
        public DocumentsController(IBusPublisher busPublisher, ITracer tracer, IDocumentsService documentsService) : base(busPublisher, tracer)
        {
            _documentsService = documentsService;
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(Guid id)
            => Single(await _documentsService.GetByIdAsync(id));

        [HttpGet("GetByExternalId/{id}")]
        public async Task<IActionResult> GetByExternalId(Guid id)
            => Single(await _documentsService.GetByExternalIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> UploadTemporaryFileAsync()
        {
            var file = HttpContext.Request.Form.Files[0];
            var guid = HttpContext.Request.Form["Guid"];

            MemoryStream ms = new MemoryStream(new byte[file.Length]);

            var command = new AddDocument(file.FileName, ms.ToArray(), guid);

            return await SendAsync(command.BindId(c => c.Id), resourceId: command.Id, resource: "documents");
        }
    }
}