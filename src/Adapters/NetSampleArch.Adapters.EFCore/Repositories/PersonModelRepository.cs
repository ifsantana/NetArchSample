using NetSampleArch.Adapters.EFCore.DataContexts.Interfaces;
using NetSampleArch.Adapters.EFCore.Models;
using NetSampleArch.Adapters.EFCore.Repositories.Interfaces;
using Serilog;

namespace NetSampleArch.Adapters.EFCore.Repositories
{
    public class PersonModelRepository : DataModelRepositoryBase<PersonDataModel>, IPersonModelRepository
    {
        public PersonModelRepository(ILogger logger, IDbContext dbContext) 
            : base(logger, dbContext)
        {

        }
    }
}
