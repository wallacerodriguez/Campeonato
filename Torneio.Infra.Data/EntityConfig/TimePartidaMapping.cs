using System.Data.Entity.ModelConfiguration;
using Torneio.Domain.Entities;

namespace Torneio.Infra.Data.EntityConfig
{
    public class TimePartidaMapping : EntityTypeConfiguration<TimePartida>
    {
        public TimePartidaMapping()
        {
            ToTable("TimePartida");

            HasKey(c => new { c.TimeId, c.PartidaId });

            HasRequired(c => c.Time).WithMany(c => c.TimesPartidas).HasForeignKey(c => c.TimeId).WillCascadeOnDelete();

            HasRequired(c => c.Partida).WithMany(c => c.TimesPartidas).HasForeignKey(c => c.PartidaId).WillCascadeOnDelete();
        }
    }
}
