namespace PayrollExercise.Services.Specification.Base
{
    public abstract class Specification<T> : ISpecification<T>
    {
        public abstract bool IsSatisfied(T entity, List<string> errors);

        public ISpecification<T> And(ISpecification<T> specification)
        {
            return new AndSpecification<T>(this, specification);
        }
    }
}
