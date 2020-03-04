using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Identity.Api.Messages.Events
{
    public class AccessTokenRefreshed : IEvent
    {
        public Guid UserId { get; }

        [JsonConstructor]
        public AccessTokenRefreshed(Guid userId)
        {
            UserId = userId;
        }
    }
}
