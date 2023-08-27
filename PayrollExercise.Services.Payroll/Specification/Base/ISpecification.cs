using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Services.Payroll.Specification.Base
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T entity, List<string> errors);
    }
}
