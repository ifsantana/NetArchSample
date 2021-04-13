using NetSampleArch.Adapters.EFCore.DataContexts.Interfaces;
using NetSampleArch.Adapters.EFCore.Models;
using NetSampleArch.Adapters.EFCore.Repositories.Interfaces;
using Serilog;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Dapper;

namespace NetSampleArch.Adapters.EFCore.Repositories
{
    public class PersonModelRepository : DataModelRepositoryBase<PersonDataModel>, IPersonModelRepository
    {
        public PersonModelRepository(ILogger logger, IDbContext dbContext) 
            : base(logger, dbContext)
        {

        }

        public async Task<PersonDataModel> AddPersonAsync(PersonDataModel dataModel, CancellationToken cancellationToken)
        {
            try
            {
                var command = @"INSERT INTO Person (Id, Name, Address, Phone, CreatedBy, UpdateddBy, CreatedAt, UpdatedAt, RowVersion)" +
                            "VALUES (@Id, @Name, @Address, @Phone, @CreatedBy, @UpdateddBy, @CreatedAt, @UpdatedAt, @RowVersion);";

                using (var connection = new SqlConnection(@"Server=localhost,1439;Initial Catalog=CDC_COMMAND_DB;User Id=sa;Password=Your_password123;ApplicationIntent=ReadWrite;"))
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
                        return await Task.FromResult(dataModel);
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
