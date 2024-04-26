namespace Pathfinder.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users_Personaggi
    {
        [Key]
        public int IdUsersPg { get; set; }

        public string Username { get; set; }

        public int IdPg { get; set; }

        public virtual Personaggi Personaggi { get; set; }

        public virtual Users Users { get; set; }
    }
}
