using MicroApp.Common.Types;
using System.Threading.Tasks;

namespace MicroApp.Common.Handlers
{
    public interface IQueryHandler<TQuery,TResult> where TQuery : IQuery<TResult>
    {
        Task<TResult> HandleAsync(TQuery query);
    }
}