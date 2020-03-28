using System;

namespace MicroApp.Api.Models.Documents
{
    public class Document
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public byte[] FileArray { get; set; }
        public Guid ExternalId { get; set; }
    }
}
