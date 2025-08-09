using Erp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Persistence.Repositories.Interface;

public interface IRepository<T> where T : BaseEntity
{
    T GetById(int id);
    T GetSingle(Expression<Func<T, bool>> filter);
    IEnumerable<T> GetAll();
    IEnumerable<T> Get(Expression<Func<T, bool>> filter);
    T Add(T entity);
    void Update(T entity);
    void Delete(T entity);
}
