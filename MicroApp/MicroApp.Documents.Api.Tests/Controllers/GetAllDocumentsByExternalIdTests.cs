using MicroApp.Documents.Api.Dto;
using MicroApp.Documents.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Documents.Api.Controllers
{
    public class GetAllDocumentsByExternalIdTests: DocumentControllerTests
    {
        [Fact]
        public async Task return_null_when_browseDocumentsByExternalId_equal_null()
        {
            // Arrange 
            BrowseDocumentsByExternalId query = null;
            _mockDispatcher.Setup(r => r.QueryAsync(query)).ReturnsAsync((DocumentDto[])null);

            // Act
            var controller = new DocumentsController(_mockDispatcher.Object);
            var result = await controller.GetAllDocumentsByExternalId(query);

            //Assert
            Assert.Null(result.Value);
            Assert.IsType<ActionResult<DocumentDto[]>>(result);
        }

        [Fact]
        public async Task return_items_when_browseDocumentsByExternalId_not_null()
        {
            // Arrange 
            var query = new BrowseDocumentsByExternalId();
            var documentDtos = new List<DocumentDto> { new DocumentDto() }.ToArray();
            _mockDispatcher.Setup(r => r.QueryAsync(query)).ReturnsAsync(documentDtos);

            // Act
            var controller = new DocumentsController(_mockDispatcher.Object);
            var result = await controller.GetAllDocumentsByExternalId(query);

            //Assert
            Assert.NotNull(result.Value);
            Assert.IsType<ActionResult<DocumentDto[]>>(result);
            Assert.Equal(documentDtos.Length, result.Value.Length);
        }
    }
}
