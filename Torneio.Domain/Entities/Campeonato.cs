using System.Collections.Generic;

namespace Torneio.Domain.Entities
{
    public class Campeonato
    {

        public int CampeonatoId { get; set; }

        public string Nome { get; set; }

        public int Quantidade { get; set; }

        public Time Campeao { get; set; }

        public virtual ICollection<TimeCampeonato> TimesCampeonatos { get; set; }

        public virtual ICollection<Partida> Partidas { get; set; }

    }
}
