namespace PayrollExercise.Services.Specification.Base
{
    public interface ISpecification<T>
    {
        bool IsSatisfied(T entity, List<string> errors);
    }
}
