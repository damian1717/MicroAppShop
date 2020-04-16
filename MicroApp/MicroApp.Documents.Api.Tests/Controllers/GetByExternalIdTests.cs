using MicroApp.Documents.Api.Dto;
using MicroApp.Documents.Api.Queries;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace MicroApp.Documents.Api.Controllers
{
    public class GetByExternalIdTests: DocumentControllerTests
    {
        [Fact]
        public async Task return_null_when_getDocumentByExternalId_equal_null()
        {
            // Arrange 
            GetDocumentByExternalId query = null;
            _mockDispatcher.Setup(r => r.QueryAsync(query)).ReturnsAsync((DocumentDto)null);

            // Act
            var controller = new DocumentsController(_mockDispatcher.Object);
            var result = await controller.GetByExternalId(query);

            //Assert
            Assert.Null(result.Value);
            Assert.IsType<ActionResult<DocumentDto>>(result);
        }

        [Fact]
        public async Task return_items_when_getDocumentByExternalId_not_null()
        {
            // Arrange 
            var query = new GetDocumentByExternalId();
            var documentDto = new DocumentDto();
            _mockDispatcher.Setup(r => r.QueryAsync(query)).ReturnsAsync(documentDto);

            // Act
            var controller = new DocumentsController(_mockDispatcher.Object);
            var result = await controller.GetByExternalId(query);

            //Assert
            Assert.NotNull(result.Result);
            Assert.IsType<ActionResult<DocumentDto>>(result);
        }
    }
}
