namespace Pathfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Abilita_Classe
    {
        [Key]
        public int IdAbilitaClasse { get; set; }

        public int IdClasse { get; set; }

        public int IdAbilita { get; set; }

        public virtual Abilita Abilita { get; set; }

        public virtual Classi Classi { get; set; }
    }
}
