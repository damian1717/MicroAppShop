using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Documents.Api.Messages.Events
{
    public class DocumentAdded : IEvent
    {
        public Guid Id { get; }
        public string FileName { get; }
        public byte[] FileArray { get; }
        public Guid ExternalId { get; }

        [JsonConstructor]
        public DocumentAdded(Guid id, string fileName, byte[] fileArray, Guid externalId)
        {
            Id = id;
            FileName = fileName;
            FileArray = fileArray;
            ExternalId = externalId;
        }
    }
}
