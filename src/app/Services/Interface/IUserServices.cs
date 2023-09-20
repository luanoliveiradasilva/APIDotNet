using src.app.Domains.Entities;

namespace src.app.Services.Interface
{
    public interface IUserServices
    {
        Task<User> Get(Guid id);
        Task<IEnumerable<User>> GetAll();
        Task<User> Post (User user);
        Task<User> Put(User user);
        Task<bool> Delete(Guid id);        
    }
}