using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetSampleArch.Adapters.EFCore.Models;

namespace NetSampleArch.Adapters.EFCore.Mappings
{
    public abstract class BaseMap<TDataModel>
    : IEntityTypeConfiguration<TDataModel>
    where TDataModel : BaseModel
    {
        private static string SCHEMA_NAME = "CDC_COMMAND_DB";

        public void Configure(EntityTypeBuilder<TDataModel> builder)
        {
            builder.ToTable(GetTableName(), SCHEMA_NAME);

            builder.HasKey(q => q.Id);
            builder.Property(q => q.Id)
                .HasColumnName("Id");

            builder.Property(q => q.CreatedAt)
                .HasColumnName("CreatedAt")
                .IsRequired();
            builder.Property(q => q.CreatedBy)
                .HasColumnName("CreatedBy")
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(q => q.UpdatedAt)
                .HasColumnName("UpdatedAt")
                .IsRequired(false);
            builder.Property(q => q.UpdatedBy)
                .HasColumnName("UpdateddBy")
                .IsRequired(false)
                .HasMaxLength(150);

            builder.Property(q => q.RowVersion)
                .HasColumnName("RowVersion")
                .HasConversion<long>()
                .IsRequired();

            ConfigureMap(builder);
        }

        protected abstract string GetTableName();

        public abstract void ConfigureMap(EntityTypeBuilder<TDataModel> builder);
    }
}
