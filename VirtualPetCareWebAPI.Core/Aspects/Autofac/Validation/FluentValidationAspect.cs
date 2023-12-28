using Castle.DynamicProxy;
using FluentValidation;
using VirtualPetCareWebAPI.Core.CrossCuttingCorners.Validation;
using VirtualPetCareWebAPI.Core.Utilities.Interceptors;

namespace VirtualPetCareWebAPI.Core.Aspects.Autofac.Validation
{
    public class FluentValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public FluentValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("This is not a verification class.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator) Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);

            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
