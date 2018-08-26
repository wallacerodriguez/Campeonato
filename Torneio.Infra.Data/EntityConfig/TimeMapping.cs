using System.Data.Entity.ModelConfiguration;
using Torneio.Domain.Entities;

namespace Torneio.Infra.Data.EntityConfig
{
    public class TimeMapping : EntityTypeConfiguration<Time>
    {
        public TimeMapping()
        {
            ToTable("Time");

            HasKey(x => x.TimeId);

            Property(x => x.TimeId);

            Property(x => x.Nome).IsRequired().HasMaxLength(60);

        }
    }
}
