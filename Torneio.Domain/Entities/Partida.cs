using System.Collections.Generic;

namespace Torneio.Domain.Entities
{
    public class Partida
    {
        public int Id { get; set; }

        public int PrimeiroTimeId { get; set; }

        public int SegundoTimeId { get; set; }

        public int GolsPrimeiroTime { get; set; }

        public int GolsSegundoTime { get; set; }

        public int CampeonatoId { get; set; }

        public virtual Campeonato Campeonato { get; set; }

        public int VencedorId()
        {
            return (GolsPrimeiroTime > GolsSegundoTime ? PrimeiroTimeId : SegundoTimeId);
        }

        public virtual ICollection<TimePartida> TimesPartidas { get; set; }
    }
}
