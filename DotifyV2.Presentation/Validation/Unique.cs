using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Threading.Tasks;

namespace DotifyV2.Presentation.Validation
{
    public class Unique : ValidationAttribute
    {

        public Unique(Type collectionType, string methodName)
        {
            CollectionType = collectionType;
            MethodName = methodName;
        }

        public Type CollectionType { get; }

        public string MethodName { get; }

        // TODO: Make this actually work...
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var collection = validationContext.GetService(CollectionType);
            var method = CollectionType.GetMethod(MethodName);
            var parameters = method.GetParameters();
            if (parameters.Length != 1)
            {
                throw new InvalidOperationException();
            }

            var task = method.Invoke(collection, new object[] { value }) as Task;

            if ((object)((dynamic)task).Result != null)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
