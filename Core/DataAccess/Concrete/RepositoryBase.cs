using Core.DataAccess.Abstract;
using Core.Entities;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Core.DataAccess.Concrete
{
    public class RepositoryBase<T, TContext> : IRepository<T>
        where T : class, IEntity, new()
        where TContext : DbContext
    {

        public RepositoryBase(TContext context)
        {
            Context = context;
        }
        private IDbContextTransaction _transaction;
        protected TContext Context { get; }

        public T Add(T t)
        {
            return Context.Add(t).Entity;
        }


        public void Delete(T t)
        {
            Context.Remove(t);
        }



        public List<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
            ? Context.Set<T>().AsNoTracking().ToList()
            : Context.Set<T>().Where(filter).AsNoTracking().ToList();
        }


        public List<T> GetAll(int pageNumber, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> queryable = Context.Set<T>();
            queryable = queryable.AsNoTracking();

            if (filter != null) queryable = queryable.Where(filter);

            return orderBy(queryable).Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

        }

        public List<T> GetAllWithFilter(int pageNumber, int pageSize, params Expression<Func<T, bool>>[] filters)
        {


            var query = Context.Set<T>().AsQueryable().AsNoTracking();
            if (filters != null)
            {
                foreach (var filter in filters)
                {
                    query = query.Where(filter);
                }
            }
            return query.ToList();

        }

        public T GetById(Expression<Func<T, bool>> filter)
        {
            return Context.Set<T>().SingleOrDefault(filter);
        }

        public T GetByName(Expression<Func<T, bool>> filter)
        {
            return Context.Set<T>().SingleOrDefault(filter);
        }

        public int GetRowCount(Expression<Func<T, bool>> filter = null)
        {
            return filter == null
            ? Context.Set<T>().AsNoTracking().Count()
            : Context.Set<T>().Where(filter).AsNoTracking().Count();
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public T Update(T t)
        {
            return Context.Update(t).Entity;
        }

        public TResult WithTransaction<TResult>(Func<TResult> actionForTransaction, Action successAction = null, Action<Exception> errorCallback = null)
        {
            var result = default(TResult);

            try
            {
                using var transaction = Context.Database.BeginTransaction();
                try
                {
                    result = actionForTransaction();
                    SaveChanges();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }

                successAction?.Invoke();
            }
            catch (Exception ex)
            {
                if (errorCallback is null)
                {
                    throw;
                }
                errorCallback(ex);
            }


            return result;
        }

        public void BeginTransaction()
        {
            if (_transaction == null)
            {
                _transaction = Context.Database.BeginTransaction();
            }
            else
            {
                throw new InvalidOperationException("Transaction is already in progress.");
            }
        }

        public void EndTransaction(bool commit = false)
        {
            if (_transaction != null)
            {
                try
                {
                    if (commit)
                    {
                        _transaction.Commit();
                    }
                    else
                    {
                        _transaction.Rollback();
                    }
                }
                finally
                {
                    _transaction.Dispose();
                    _transaction = null;
                }
            }
            else
            {
                throw new InvalidOperationException("No transaction is in progress.");
            }
        }

    }
}
