
using Data.Interface;
using Domains.Models;
using Services.Interface;

namespace Services;
public class UserService : IUserServices
{
    private readonly IRepository<User> iRepository;

    public UserService(IRepository<User> iRepository)
    {
        this.iRepository = iRepository;
    }

    public async Task<bool> Delete(Guid id) => await iRepository.DeleteAsync(id);
    public async Task<User> Get(Guid id) => await iRepository.SelectAsync(id);
    public async Task<IEnumerable<User>> GetAll() => await iRepository.SelectAsync();
    public async Task<User> Post(User user) => await iRepository.InsertAsync(user);
    public async Task<User> Put(User user) => await iRepository.UpdateAsync(user);
}