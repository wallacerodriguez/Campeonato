namespace Torneio.Domain.Entities
{
    public class TimePartida
    {

        public int PartidaId { get; set; }

        public int TimeId { get; set; }

        public virtual Time Time { get; set; }

        public virtual Partida Partida { get; set; }
    }
}
