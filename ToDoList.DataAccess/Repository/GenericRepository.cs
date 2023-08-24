using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess.IRepository;

namespace ToDoList.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext applicationDbContext;
        private readonly DbSet<T> dbSet;

        public GenericRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
            this.dbSet = applicationDbContext.Set<T>();
        }
        public async Task<T> Create(T entity)
        {
            await dbSet.AddAsync(entity);
            await Save();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            dbSet.Remove(entity);
            await Save();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll(string[] includeProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }
            return await query.ToListAsync();
        }

        public async Task<T> GetById(System.Linq.Expressions.Expression<Func<T, bool>> predicate, string[] includeProperties=null)
        {
            IQueryable<T> query = dbSet;
            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if (includeProperties != null)
            {
                foreach (var property in includeProperties)
                {
                    query = query.Include(property);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task Save()
        {
            await applicationDbContext.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            dbSet.Update(entity);
            await Save();
            return entity;
        }
    }
}
