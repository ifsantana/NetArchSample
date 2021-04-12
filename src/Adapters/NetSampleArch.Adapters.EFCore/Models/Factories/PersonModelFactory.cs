using NetSampleArch.Adapters.EFCore.Models.Factories.Interfaces;

namespace NetSampleArch.Adapters.EFCore.Models.Factories
{
    public class PersonModelFactory : IPersonModelFactory
    {
        public PersonDataModel Create(Domain.Entities.Person.Person parameter)
        {
            var personModel = Create();

            personModel.Id = parameter.Id;
            personModel.CreatedAt = parameter.CreatedAt;
            personModel.CreatedBy = parameter.CreatedBy;
            personModel.UpdatedAt = parameter.UpdatedAt;
            personModel.UpdatedBy = parameter.UpdatedBy;
            personModel.RowVersion = parameter.RowVersion;
            personModel.Name = parameter.Name;
            personModel.Address = parameter.Address;
            personModel.Phone = parameter.Phone;

            return personModel;
        }

        public PersonDataModel Create()
        {
            return new PersonDataModel();
        }
    }
}
