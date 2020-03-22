using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Documents.Api.Messages.Events
{
    public class AddDocumentRejected : IRejectedEvent
    {
        public Guid Id { get; }
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public AddDocumentRejected(Guid id, string reason, string code)
        {
            Id = id;
            Reason = reason;
            Code = code;
        }
    }
}
