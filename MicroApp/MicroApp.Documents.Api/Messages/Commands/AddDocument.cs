using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Documents.Api.Messages.Commands
{
    public class AddDocument : ICommand
    {
        public Guid Id { get; }
        public string FileName { get; }
        public byte[] FileArray { get; }
        public Guid ExternalId { get; }

        [JsonConstructor]
        public AddDocument(Guid id, string fileName, byte[] fileArray, Guid externalId)
        {
            Id = id;
            FileName = fileName;
            FileArray = fileArray;
            ExternalId = externalId;
        }
    }
}
