using System.Threading.Tasks;

namespace MicroApp.Common.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}
