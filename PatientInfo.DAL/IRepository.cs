using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PatientInfo.DAL
{
    public interface IRepository<T> where T : class
    {
        Task<bool>  Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(T entity);
       Task<T> GetbyId(int id);
        Task<IQueryable<T>> Find(Expression<Func<T, bool>> expression);
        Task<IEnumerable<T>> GetAll();
    }
}
