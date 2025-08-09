using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Erp.Persistence.Repositories.Interface;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Filter { get; }
    List<Expression<Func<T, object>>> Includes { get; }
    List<string> IncludeStrings { get; }
}
