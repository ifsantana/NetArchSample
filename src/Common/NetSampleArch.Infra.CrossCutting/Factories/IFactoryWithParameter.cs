namespace NetSampleArch.Infra.CrossCutting.Factories
{
    public interface IFactoryWithParameter<out T, TParameter> : IFactory<T>
    {
        T Create(TParameter parameter);
    }
}