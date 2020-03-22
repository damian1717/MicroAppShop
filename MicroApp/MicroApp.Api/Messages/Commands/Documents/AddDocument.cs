using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Api.Messages.Commands.Documents
{
    [MessageNamespace("documents")]
    public class AddDocument : ICommand
    {
        public Guid Id { get; }
        public string FileName { get; }
        public byte[] FileArray { get; }
        public string  ExternalId { get; }

        [JsonConstructor]
        public AddDocument(string fileName, byte[] fileArray, string externalId)
        {
            FileName = fileName;
            FileArray = fileArray;
            ExternalId = externalId;
        }
    }
}
