using System;

namespace MicroApp.Common.Types
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
