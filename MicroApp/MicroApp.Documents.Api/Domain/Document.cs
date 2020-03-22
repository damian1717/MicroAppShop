using MicroApp.Common.Types;
using System;

namespace MicroApp.Documents.Api.Domain
{
    public class Document : IIdentifiable
    {
        public Guid Id { get; }
        public string FileName { get; }
        public byte[] FileArray { get; }
        public string ExternalId { get; }
        protected Document()
        {
        }

        public Document(Guid id, string fileName, byte[] fileArray, string externalId)
        {
            Id = id;
            FileName = fileName;
            FileArray = fileArray;
            ExternalId = externalId;
        }
    }
}
