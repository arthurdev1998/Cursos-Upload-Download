

using Data.Contexto.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DataContext _dataContext;


        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            _dataContext.Set<T>().Remove(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dataContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            if (id <= 0)
            {
               throw new ArgumentException("O Id deve ser maior que zero.", nameof(id));
            }

            return await _dataContext.Set<T>().FindAsync(id);
        }

        public async Task Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("O campo nao pode ser nulo.");
            }
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        public async Task Update(int id, T entity)
        {
            _dataContext.Set<T>().Update(entity);
            await _dataContext.SaveChangesAsync();
        }
    }

}
