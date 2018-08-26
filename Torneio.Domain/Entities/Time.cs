using System.Collections.Generic;

namespace Torneio.Domain.Entities
{
    public class Time
    {
        public int TimeId { get; set; }

        public string Nome { get; set; }

        public int QuantidadeVitorias { get; set; }

        public virtual ICollection<TimeCampeonato> TimesCampeonatos { get; set; }

        public virtual ICollection<TimePartida> TimesPartidas { get; set; }

    }
}
