namespace Torneio.Domain.Entities
{
    public class TimeCampeonato
    {
        public int TimeId { get; set; }

        public int CampeonatoId { get; set; }

        public Campeonato Campeonato { get; set; }

        public Time Time { get; set; }
    }
}
