using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollExercise.Services.Payroll.Specification.Base
{
    public class AndSpecification<T> : Specification<T>
    {
        private readonly ISpecification<T> _left;
        private readonly ISpecification<T> _right;

        public AndSpecification(ISpecification<T> left, ISpecification<T> right)
        {
            _left = left;
            _right = right;
        }

        public override bool IsSatisfied(T entity, List<string> errors)
        {
            return this._left.IsSatisfied(entity, errors) && this._right.IsSatisfied(entity, errors);
        }
    }
}
