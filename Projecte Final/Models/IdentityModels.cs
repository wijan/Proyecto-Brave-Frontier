using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace Projecte_Final.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        //
        public virtual List<Equipo> EquipsAlsQualsPertanyAquestUsuari { get; set; }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        
        public DbSet<BB> BB { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here
            //BB
            modelBuilder.Entity<BB>().HasKey(x => x.ID);
            modelBuilder.Entity<BB>().HasRequired(x => x.RamaBB).WithMany(x => x.BBS).HasForeignKey(x => x.RamaBBID);
            modelBuilder.Entity<BB>().HasRequired(x => x.TipoBB).WithMany(x => x.BBS).HasForeignKey(x =>x.TipoBBID);
            modelBuilder.Entity<BB>().HasRequired(x => x.GrupalBB).WithMany(x => x.BBS).HasForeignKey(x => x.GrupalBBID); 
            modelBuilder.Entity<BB>().HasRequired(x => x.EfectoBB).WithMany(x => x.BBS).HasForeignKey(x => x.EfectoBBID); 

            //Crafteo
            modelBuilder.Entity<Crafteo>().HasKey(x => x.ID);

            //EfectoEsfera
            modelBuilder.Entity<EfectoEsfera>().HasKey(x => x.EfectoID);

            //Efectos
            modelBuilder.Entity<Efectos>().HasKey(x => x.EfectoBBID);

            //Elemento
            modelBuilder.Entity<Elemento>().HasKey(x => x.ID);
            modelBuilder.Entity<Elemento>().HasOptional(x => x.DebilVS).WithMany(x => x.Elementos).HasForeignKey(x => x.DebilVSID);
            modelBuilder.Entity<Elemento>().HasOptional(x => x.FuerteVS).WithMany(x => x.Elementos).HasForeignKey(x => x.FuerteVSID); ;

            //Equipo
            modelBuilder.Entity<Equipo>().HasKey(x => x.ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad1).WithMany(x => x.Equipos).HasForeignKey(x => x.Unidad1ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad2).WithMany(x => x.Equipos).HasForeignKey(x => x.Unidad2ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad3).WithMany(x => x.Equipos).HasForeignKey(x => x.Unidad3ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad4).WithMany(x => x.Equipos).HasForeignKey(x => x.Unidad4ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad5).WithMany(x => x.Equipos).HasForeignKey(x => x.Unidad5ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad6).WithMany(x => x.Equipos).HasForeignKey(x => x.Unidad6ID);
            modelBuilder.Entity<Equipo>().HasRequired(x => x.Usuario).WithMany(x => x.EquipsAlsQualsPertanyAquestUsuari).HasForeignKey(x => x.Unidad1ID);

            //ES


            //Esfera
            modelBuilder.Entity<Esfera>().HasKey(x => x.ID);
            modelBuilder.Entity<Esfera>().HasOptional(x => x.Crafteo);
            modelBuilder.Entity<Esfera>().HasRequired(x => x.TipoEsfera);
            modelBuilder.Entity<Esfera>().HasRequired(x => x.Efecto);

            //Genero
            modelBuilder.Entity<Genero>().HasKey(x => x.ID);

            //GrupalBB
            modelBuilder.Entity<GrupalBB>().HasKey(x => x.ID);

            //Objeto
            modelBuilder.Entity<Objeto>().HasKey(x => x.ID);
            modelBuilder.Entity<Objeto>().HasOptional(x => x.Crafteo);

            //Personaje
            modelBuilder.Entity<Personaje>().HasKey(x => x.Numero);
            modelBuilder.Entity<Personaje>().HasRequired(x => x.Elemento).WithMany(x => x.Personajes).HasForeignKey(x => x.ElementoID);
            modelBuilder.Entity<Personaje>().HasRequired(x => x.Genero).WithMany(x => x.Personajes).HasForeignKey(x => x.GeneroID);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.BB).WithMany(x => x.Personajes).HasForeignKey(x => x.BBID);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.SBB).WithMany(x => x.Personajes).HasForeignKey(x => x.SBBID);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.UBB).WithMany(x => x.Personajes).HasForeignKey(x => x.UBBID);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.ES).WithMany(x => x.Personajes).HasForeignKey(x => x.ESID);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.LS).WithMany(x => x.Personajes).HasForeignKey(x => x.LSID);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.PreEvo).WithMany(x => x.Personajes).HasForeignKey(x => x.PreEvoNum);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.PostEvo).WithMany(x => x.Personajes).HasForeignKey(x => x.PostEvoNum);

            //RamaBB
            modelBuilder.Entity<RamaBB>().HasKey(x => x.ID);

            //Stats
            modelBuilder.Entity<Stats>().HasKey(x => x.ID);
            modelBuilder.Entity<Stats>().HasRequired(x => x.Personaje).WithMany(x => x.Stats);

            //TipoBB
            modelBuilder.Entity<TipoBB>().HasKey(x => x.TipoID);

            //TipoEsfera
            modelBuilder.Entity<TipoEsfera>().HasKey(x => x.ID);

            //Unidad
            modelBuilder.Entity<Unidad>().HasKey(x => x.ID);
            modelBuilder.Entity<Unidad>().HasRequired(x => x.Personaje).WithMany(x => x.Unidades).HasForeignKey(x => x.PersonajeID);



            /*
            modelBuilder.Entity<Blog>().HasKey(x => x.BlogId);
            modelBuilder.Entity<Post>().HasKey(x => x.PostId);
            modelBuilder.Entity<Post>().HasRequired(x => x.Blog)
                                       .WithMany(x => x.Posts)
                                       .HasForeignKey(x => x.BlogId)
                                       .WillCascadeOnDelete(true);*/





            base.OnModelCreating(modelBuilder);
        }



    }
}