using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        T Add(T t);
        T Update(T t);
        void Delete(T t);

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
        List<T> GetAll(int pageNumber, int pageSize,Func<IQueryable<T>,IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> filter = null);
        T GetById(Expression<Func<T, bool>> filter);
        T GetByName(Expression<Func<T, bool>> filter);
        List<T> GetAllWithFilter(int pageNumber, int pageSize, params Expression<Func<T, bool>>[] filters);
        int GetRowCount(Expression<Func<T, bool>> filter = null);
        
        TResult WithTransaction<TResult>(Func<TResult> actionForTransaction,Action successAction,Action<Exception> errorCallback);
        void BeginTransaction();
        void EndTransaction(bool commit = false);
        int SaveChanges();
    }
}
