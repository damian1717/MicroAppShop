using MicroApp.Common.Types;
using System.Threading.Tasks;

namespace MicroApp.Common.Dispatcher
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TResult>(IQuery<TResult> query);
    }
}
