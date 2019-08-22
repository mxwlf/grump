
namespace Grump.ValidationExtensions
{
    public abstract class ValidationDefinition<T>
    {
        public T ValidatedSpecimen { get; set; }

        public ValidationDefinition(T validatedSpecimen)
        {
            ValidatedSpecimen = validatedSpecimen;
        }
        
    }
        
}
