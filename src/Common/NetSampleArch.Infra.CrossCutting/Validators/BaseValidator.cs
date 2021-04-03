using FluentValidation;

namespace NetSampleArch.Infra.CrossCutting.Validators
{
   public abstract class ValidatorBase<T>
        : AbstractValidator<T>
    {
    }
}