using System.Data.Entity.ModelConfiguration;
using Torneio.Domain.Entities;

namespace Torneio.Infra.Data.EntityConfig
{
    public class CampeonatoMapping : EntityTypeConfiguration<Campeonato>
    {
        public CampeonatoMapping()
        {
            ToTable("Campeonato");

            HasKey(x => x.CampeonatoId);

            Property(x => x.Nome).IsRequired().HasMaxLength(40);

            Property(x => x.Quantidade).IsRequired();

            Ignore(c => c.Campeao);
        }
    }
}
