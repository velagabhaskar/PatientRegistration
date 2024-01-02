using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using PatientInfo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PatientInfo.DAL
{
    public  class Repository<T> : IRepository<T> where T : class

    {
        PatientDataContext _Context;
      
        private readonly DbSet<T> _dbSet;
        public Repository(PatientDataContext Context)
        {
            _Context=Context;
            _dbSet = Context.Set<T>();
        }

        public async Task<bool> Add(T entity)
        {
          await _Context.Set<T>().AddAsync(entity);
            await _Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(T entity)
        {
            
            _Context.Set<T>().Update(entity) ;
            
             await _Context.SaveChangesAsync();
            return true;
        }

        public async Task<IQueryable<T>> Find(Expression<Func<T, bool>> expression)
        {
            return _Context.Set<T>().Where(expression).AsNoTracking();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
            }

        public async Task<bool> Update(T entity)
        {
                _dbSet.Attach(entity);
                var entry = _Context.Entry(entity);
                entry.State = EntityState.Modified;
               
                _Context.Set<T>().Update(entity);
               // _Context.Set<T>().Update(entity).State = EntityState.Modified;
                await _Context.SaveChangesAsync();
                return true;
          
        
           
        }



        public async Task<T> GetbyId(int id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
