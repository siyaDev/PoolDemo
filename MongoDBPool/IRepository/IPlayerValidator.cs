using MongoDBPool.Models;

namespace MongoDBPool.IRepository
{
    public interface IPlayerValidator
    {
        bool EmailValidator(Player player);
    }
}