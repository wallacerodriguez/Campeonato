namespace Torneio.MVC.ViewModel
{
    public class TimeCampeonatoViewModel
    {
        public int TimeId { get; set; }

        public int CampeonatoId { get; set; }

        public virtual CampeonatoViewModel Campeonato { get; set; }

        public virtual TimeViewModel Time { get; set; }
    }
}