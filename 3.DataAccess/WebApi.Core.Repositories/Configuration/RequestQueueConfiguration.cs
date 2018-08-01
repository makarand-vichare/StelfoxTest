using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Net.Core.EntityModels.Queues;

namespace Net.Core.Repositories.Configuration
{
    internal class RequestQueueConfiguration : IEntityTypeConfiguration<RequestQueue>
    {
        public void Configure(EntityTypeBuilder<RequestQueue> builder)
        {
            builder.ToTable("RequestQueues").HasKey(x => x.Id);

            builder.Property(x => x.Id)
                 .HasColumnName("Id")
                 .HasColumnType("bigint")
                 .ValueGeneratedOnAdd()
                 .IsRequired();

            builder.Property(x => x.SearchParameters)
                .HasColumnName("SearchParameters")
                .HasColumnType("nvarchar(MAX)");

            builder.Property(x => x.IsRequestSucceed)
                .HasColumnName("IsRequestSucceed")
                .HasColumnType("bit")
                .IsRequired();

            builder.Property(x => x.ErrorMessage)
                .HasColumnName("ErrorMessage")
                .HasColumnType("nvarchar(MAX)");
        }
    }
}
