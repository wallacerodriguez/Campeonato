using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Torneio.MVC.ViewModel
{
    public class CampeonatoViewModel
    {
        [Key]
        public int CampeonatoId { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório")]
        public int Quantidade { get; set; }

        [ScaffoldColumn(false)]
        public virtual TimeViewModel Campeao { get; set; }

        public virtual ICollection<TimeCampeonatoViewModel> TimesCampeonatos { get; set; }

        public List<int> TimeId { get; set; }
    }
}