using Microsoft.EntityFrameworkCore;
using ShopBridge.API.Repository.Interface;
using ShopBridge.API.UOW.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ShopBridge.API.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            _unitOfWork._context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            if (entity != null)
                _unitOfWork._context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _unitOfWork._context.Set<T>().Attach(entity);
            _unitOfWork._context.Entry<T>(entity).State = EntityState.Modified;
        }

        public IEnumerable<T> Get()
        {
            return _unitOfWork._context.Set<T>().AsEnumerable<T>();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _unitOfWork._context.Set<T>().Where(predicate).AsEnumerable<T>();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();

        }
    }
}
