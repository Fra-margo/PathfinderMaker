namespace Pathfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            Users_Personaggi = new HashSet<Users_Personaggi>();
        }

        [Key]
        [Required(ErrorMessage = "Il campo Username è obbligatorio.")]
        [StringLength(50, ErrorMessage = "Il campo Username non può superare i 50 caratteri.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Il campo Password è obbligatorio.")]
        [StringLength(255, ErrorMessage = "Il campo Password non può superare i 255 caratteri.")]
        public string Password { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Users_Personaggi> Users_Personaggi { get; set; }
    }
}
