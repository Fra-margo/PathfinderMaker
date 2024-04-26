namespace Pathfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Personaggi")]
    public partial class Personaggi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Personaggi()
        {
            Users_Personaggi = new HashSet<Users_Personaggi>();
        }

        [Key]
        public int IdPg { get; set; }
        public string Img { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required]
        public int IdRazza { get; set; }
        [Required]
        public int IdClasse { get; set; }
        [Required]
        public int Forza { get; set; }
        [Required]
        public int Destrezza { get; set; }
        [Required]
        public int Costituzione { get; set; }
        [Required]
        public int Intelligenza { get; set; }
        [Required]
        public int Saggezza { get; set; }
        [Required]
        public int Carisma { get; set; }

        public int PuntiVita { get; set; }

        public int Livello { get; set; }

        public virtual Classi Classi { get; set; }

        public virtual Razze Razze { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users_Personaggi> Users_Personaggi { get; set; }
        public virtual ICollection<Abilita_Personaggio> Abilita_Personaggio { get; set; }
    }
}
