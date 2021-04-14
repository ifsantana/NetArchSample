using NetSampleArch.Adapters.EFCore.DataContexts.Interfaces;
using NetSampleArch.Adapters.EFCore.Models;
using NetSampleArch.Adapters.EFCore.Repositories.Interfaces;
using Serilog;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using System.Text.Json;

namespace NetSampleArch.Adapters.EFCore.Repositories
{
    public class PersonModelRepository : DataModelRepositoryBase<PersonDataModel>, IPersonModelRepository
    {
        private readonly IDbContext _dbContext;

        public PersonModelRepository(ILogger logger, IDbContext dbContext) 
            : base(logger, dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<PersonDataModel> AddPersonAsync(PersonDataModel dataModel, CancellationToken cancellationToken)
        {
            try
            {
                var command = @"INSERT INTO Person (Id, Name, Address, Phone, CreatedBy, UpdateddBy, CreatedAt, UpdatedAt, RowVersion)" +
                            "VALUES (@Id, @Name, @Address, @Phone, @CreatedBy, @UpdateddBy, @CreatedAt, @UpdatedAt, @RowVersion);";

                using (var connection = _dbContext.GetSqlSession())
                {
                    var affectedRows = await connection.ExecuteAsync(command, new
                    {
                        Id = dataModel.Id,
                        Name = dataModel.Name,
                        Address = dataModel.Address,
                        Phone = dataModel.Phone,
                        CreatedBy = dataModel.CreatedBy,
                        UpdateddBy = dataModel.UpdatedBy,
                        CreatedAt = dataModel.CreatedAt,
                        UpdatedAt = dataModel.UpdatedAt,
                        RowVersion = dataModel.RowVersion.Ticks
                    });

                    if (affectedRows > 0)
                    {
                        Logger.Information($"User persisted on Command Database. {JsonSerializer.Serialize(dataModel)}");
                        return await Task.FromResult(dataModel);
                    }
                }

                return await Task.FromResult(default(PersonDataModel));
            }
            catch (System.Exception ex)
            {
                return await Task.FromResult(default(PersonDataModel));
            }
        }
    }
}
