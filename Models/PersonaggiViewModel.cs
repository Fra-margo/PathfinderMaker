using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pathfinder.Models
{
    public class PersonaggiViewModel
    {
        [Required(ErrorMessage = "Devi scegliere un Nome")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Devi scegliere una Razza")]
        public int IdRazza { get; set; }
        [Required(ErrorMessage = "Devi scegliere una Classe")]
        public int IdClasse { get; set; }
        public int Forza { get; set; }

        public int Destrezza { get; set; }

        public int Costituzione { get; set; }

        public int Intelligenza { get; set; }

        public int Saggezza { get; set; }

        public int Carisma { get; set; }

        public int PuntiVita { get; set; }
        public int Livello { get; set; }       

        public List<Razze> RazzeList { get; set; }
        public List<Classi> ClassiList { get; set; }
        public List<string> AbilitaClasse { get; set; }
        public List<AbilitaViewModel> AbilitaList { get; set; }
        public PersonaggiViewModel()
        {
            Livello = 1;
        }

        public class AbilitaViewModel
        {
            public int IdAbilita { get; set; }
            public string Nome { get; set; }
            public int Valore { get; set; }
        }
    }    
}