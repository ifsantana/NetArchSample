namespace NetSampleArch.Infra.CrossCutting.Validators
{
    public interface IValidator<in T>
        : FluentValidation.IValidator<T>
    {

    }
}