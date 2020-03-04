using MicroApp.Common.Messages;
using Newtonsoft.Json;
using System;

namespace MicroApp.Identity.Api.Messages.Events
{
    public class PasswordChanged : IEvent
    {
        public Guid UserId { get; }

        [JsonConstructor]
        public PasswordChanged(Guid userId)
        {
            UserId = userId;
        }
    }
}
