using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetSampleArch.Adapters.EFCore.Models;

namespace NetSampleArch.Adapters.EFCore.Mappings
{
    public class PersonModelMap : BaseMap<PersonDataModel>
    {
        private static string TABLE_NAME = "Person";

        protected override string GetTableName() => TABLE_NAME;

        public override void ConfigureMap(EntityTypeBuilder<PersonDataModel> builder)
        {
            builder.Property(q => q.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(q => q.Address)
                            .HasColumnName("Address")
                            .IsRequired()
                            .HasMaxLength(100);

            builder.Property(q => q.Phone)
                            .HasColumnName("Phone")
                            .HasMaxLength(100);
        }
    }
}
