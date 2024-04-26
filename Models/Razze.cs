namespace Pathfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Razze")]
    public partial class Razze
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Razze()
        {
            Personaggi = new HashSet<Personaggi>();
        }

        [Key]
        public int IdRazza { get; set; }

        [Required]
        [StringLength(50)]
        public string Tipologia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Personaggi> Personaggi { get; set; }
    }
}
