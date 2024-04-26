namespace Pathfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("Abilita")]
    public partial class Abilita
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Abilita()
        {
            Abilita_Classe = new HashSet<Abilita_Classe>();
        }

        [Key]
        public int IdAbilita { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [StringLength(50)]
        public string CaratteristicaAssociata { get; set; }

        [StringLength(50)]
        public string Tipo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abilita_Classe> Abilita_Classe { get; set; }
        public virtual ICollection<Abilita_Personaggio> Abilita_Personaggio { get; set; }
    }
}
