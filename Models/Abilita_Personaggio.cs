using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pathfinder.Models
{
    [Table("Abilita_Personaggio")]
    public partial class Abilita_Personaggio
    {
        [Key]
        public int IdAbilitaPersonaggio { get; set; }
        public int IdPg { get; set; }
        public int IdAbilita { get; set; }
        public int Valore { get; set; }
        [ForeignKey("IdAbilita")]
        public virtual Abilita Abilita { get; set; }
        [ForeignKey("IdPg")]
        public virtual Personaggi Personaggi { get; set; }
    }
}