using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Driven.Design.Application.Entities;

namespace Data.Driven.Design.Application.IRepository
{
    public interface IBaseRepository<TEntity> where TEntity : Entity
    {
        Task InsertAsync(TEntity obj);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task UpdateAsync(TEntity obj);
        Task DeleteAsync(TEntity obj);
    }
}
