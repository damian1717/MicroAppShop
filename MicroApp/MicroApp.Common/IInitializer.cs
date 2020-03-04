using System.Threading.Tasks;

namespace MicroApp.Common
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}
