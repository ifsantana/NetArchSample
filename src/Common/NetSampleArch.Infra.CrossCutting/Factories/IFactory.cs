namespace NetSampleArch.Infra.CrossCutting.Factories
{
    public interface IFactory<out T>
    {
        T Create();
    }
}