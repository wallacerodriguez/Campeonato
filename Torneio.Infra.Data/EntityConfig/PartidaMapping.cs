using System.Data.Entity.ModelConfiguration;
using Torneio.Domain.Entities;

namespace Torneio.Infra.Data.EntityConfig
{
    public class PartidaMapping : EntityTypeConfiguration<Partida>
    {
        public PartidaMapping()
        {
            ToTable("Partidas");

            HasKey(c => c.Id);

            HasRequired(c => c.Campeonato).WithMany(c => c.Partidas).HasForeignKey(c => c.CampeonatoId).WillCascadeOnDelete();

        }
    }
}
