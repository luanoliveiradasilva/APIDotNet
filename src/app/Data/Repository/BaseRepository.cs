
using Data.Context;
using Data.Interface;
using Domains.Models;
using Microsoft.EntityFrameworkCore;

namespace src.app.Data.Repository;

public class BaseRepository<T> : IRepository<T> where T : BaseEntity
{

    protected readonly AppContexts appContexts;

    private DbSet<T> dataSet;

    public BaseRepository(AppContexts appContexts)
    {
        this.appContexts = appContexts;
        dataSet = appContexts.Set<T>();
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        try
        {
            var result = await dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));

            if (result == null)
                return false;

            dataSet.Remove(result);

            await appContexts.SaveChangesAsync();

            return true;

        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<bool> ExistAsync(Guid id)
    {
        return await dataSet.AnyAsync(p => p.Id.Equals(id));
    }

    public async Task<T> InsertAsync(T item)
    {
        try
        {
            if (item.Id == Guid.Empty)
            {
                item.Id = Guid.NewGuid();
            }

            item.CreateAt = DateTime.UtcNow;
            await appContexts.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

        return item;
    }

    public async Task<T> SelectAsync(Guid id)
    {
        try
        {
            return await dataSet.SingleOrDefaultAsync(p => p.Id.Equals(id));
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<IEnumerable<T>> SelectAsync()
    {
        try
        {
            return await dataSet.ToListAsync();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public async Task<T> UpdateAsync(T item)
    {
        try
        {
            var result = await dataSet.SingleOrDefaultAsync(p => p.Id.Equals(item.Id));

            if (result == null)
                return null;

            item.UpdateAt = DateTime.UtcNow;
            item.CreateAt = result.CreateAt;

            appContexts.Entry(result).CurrentValues.SetValues(item);

            await appContexts.SaveChangesAsync();
        }
        catch (Exception)
        {
            throw;
        }

        return item;
    }
}