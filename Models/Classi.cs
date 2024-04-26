namespace Pathfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Classi")]
    public partial class Classi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Classi()
        {
            Abilita_Classe = new HashSet<Abilita_Classe>();
            Personaggi = new HashSet<Personaggi>();
        }

        [Key]
        public int IdClasse { get; set; }

        [StringLength(50)]
        public string Nome { get; set; }

        public int Livello { get; set; }

        public int BonusAttaccoBase { get; set; }

        public int TSTempra { get; set; }

        public int TSRiflessi { get; set; }

        public int TSVolonta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Abilita_Classe> Abilita_Classe { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personaggi> Personaggi { get; set; }
    }
}
