using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Identity.Api.Messages.Events
{
    public class RefreshTokenRevoked : IEvent
    {
        public Guid UserId { get; }

        [JsonConstructor]
        public RefreshTokenRevoked(Guid userId)
        {
            UserId = userId;
        }
    }
}
