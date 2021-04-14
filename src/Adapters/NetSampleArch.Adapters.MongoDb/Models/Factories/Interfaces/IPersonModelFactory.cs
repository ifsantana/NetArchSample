using NetSampleArch.Infra.CrossCutting.Factories;

namespace NetSampleArch.Adapters.MongoDb.Models.Factories.Interfaces
{
    public interface IPersonModelFactory : IFactoryWithParameter<PersonDataModel, Domain.Entities.Person.Person>
    {
    }
}
