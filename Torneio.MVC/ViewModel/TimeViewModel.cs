using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Torneio.MVC.ViewModel
{
    public class TimeViewModel
    {
        [Key]
        public int TimeId { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório")]
        public string Nome { get; set; }

        [ScaffoldColumn(false)]
        public int QuantidadeVitorias { get; set; }

        public virtual ICollection<TimeCampeonatoViewModel> TimesCampeonatos { get; set; }
    }
}