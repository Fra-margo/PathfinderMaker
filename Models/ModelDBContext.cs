using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Pathfinder.Models
{
    public partial class ModelDBContext : DbContext
    {
        public ModelDBContext()
            : base("name=ModelDBContext")
        {
        }

        public virtual DbSet<Abilita> Abilita { get; set; }
        public virtual DbSet<Abilita_Classe> Abilita_Classe { get; set; }
        public virtual DbSet<Abilita_Personaggio> Abilita_Personaggio{ get; set; }
        public virtual DbSet<Classi> Classi { get; set; }
        public virtual DbSet<Personaggi> Personaggi { get; set; }
        public virtual DbSet<Razze> Razze { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Users_Personaggi> Users_Personaggi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abilita>()
                .HasMany(e => e.Abilita_Classe)
                .WithRequired(e => e.Abilita)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Abilita>()
                .HasMany(e => e.Abilita_Personaggio)
                .WithRequired(e => e.Abilita)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classi>()
                .HasMany(e => e.Abilita_Classe)
                .WithRequired(e => e.Classi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Classi>()
                .HasMany(e => e.Personaggi)
                .WithRequired(e => e.Classi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personaggi>()
                .HasMany(e => e.Users_Personaggi)
                .WithRequired(e => e.Personaggi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Personaggi>()
                .HasMany(e => e.Abilita_Personaggio)
                .WithRequired(e => e.Personaggi)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Razze>()
                .HasMany(e => e.Personaggi)
                .WithRequired(e => e.Razze)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Users_Personaggi)
                .WithRequired(e => e.Users)
                .WillCascadeOnDelete(false);
        }
    }
}
