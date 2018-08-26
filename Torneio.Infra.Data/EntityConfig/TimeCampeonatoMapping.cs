using System.Data.Entity.ModelConfiguration;
using Torneio.Domain.Entities;

namespace Torneio.Infra.Data.EntityConfig
{
    public class TimeCampeonatoMapping : EntityTypeConfiguration<TimeCampeonato>
    {
        public TimeCampeonatoMapping()
        {
            ToTable("TimeCampeonato");

            HasKey(c => new { c.TimeId, c.CampeonatoId });

            HasRequired(c => c.Time).WithMany(c => c.TimesCampeonatos).HasForeignKey(c => c.TimeId).WillCascadeOnDelete();

            HasRequired(c => c.Campeonato).WithMany(c => c.TimesCampeonatos).HasForeignKey(c => c.CampeonatoId).WillCascadeOnDelete(); ;
        }
    }
}
