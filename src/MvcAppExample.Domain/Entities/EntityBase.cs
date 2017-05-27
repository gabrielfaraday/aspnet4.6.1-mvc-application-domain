using DomainValidation.Validation;

namespace MvcAppExample.Domain.Entities
{
    public abstract class EntityBase
    {
        public ValidationResult ValidationResult { get; set; }
    }
}
