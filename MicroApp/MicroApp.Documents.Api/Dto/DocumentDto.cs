using System;

namespace MicroApp.Documents.Api.Dto
{
    public class DocumentDto
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileArray { get; set; }
        public string ExternalId { get; set; }
    }
}
