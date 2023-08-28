namespace PayrollExercise.Services.Specification.Base
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
            return _left.IsSatisfied(entity, errors) && _right.IsSatisfied(entity, errors);
        }
    }
}
