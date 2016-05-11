using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

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
            modelBuilder.Entity<BB>().HasRequired(x => x.RamaBB);
            modelBuilder.Entity<BB>().HasRequired(x => x.TipoBB);
            modelBuilder.Entity<BB>().HasRequired(x => x.GrupalBB);
            modelBuilder.Entity<BB>().HasRequired(x => x.EfectoBB);

            //Crafteo
            modelBuilder.Entity<Crafteo>().HasKey(x => x.ID);

            //EfectoEsfera
            modelBuilder.Entity<EfectoEsfera>().HasKey(x => x.EfectoID);

            //Efectos
            modelBuilder.Entity<Efectos>().HasKey(x => x.EfectoBBID);

            //Elemento
            modelBuilder.Entity<Elemento>().HasKey(x => x.ID);
            modelBuilder.Entity<Elemento>().HasOptional(x => x.DebilVS);
            modelBuilder.Entity<Elemento>().HasOptional(x => x.FuerteVS);

            //Equipo
            modelBuilder.Entity<Equipo>().HasKey(x => x.ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad1);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad2);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad3);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad4);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad5);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad6);
            modelBuilder.Entity<Equipo>().HasRequired(x => x.Usuario);

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
            modelBuilder.Entity<Personaje>().HasRequired(x => x.Elemento);
            modelBuilder.Entity<Personaje>().HasRequired(x => x.Genero);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.BB);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.SBB);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.UBB);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.ES);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.LS);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.PreEvo);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.PostEvo);

            //RamaBB
            modelBuilder.Entity<RamaBB>().HasKey(x => x.ID);

            //Stats
            modelBuilder.Entity<Stats>().HasKey(x => x.ID);
            modelBuilder.Entity<Stats>().HasRequired(x => x.Personaje);

            //TipoBB
            modelBuilder.Entity<TipoBB>().HasKey(x => x.TipoID);

            //TipoEsfera
            modelBuilder.Entity<TipoEsfera>().HasKey(x => x.ID);

            //Unidad
            modelBuilder.Entity<Unidad>().HasKey(x => x.ID);
            modelBuilder.Entity<Unidad>().HasRequired(x => x.Personaje);
            modelBuilder.Entity<Unidad>().HasRequired(x => x.Equipo);




            modelBuilder.Entity<Blog>().HasKey(x => x.BlogId);
            modelBuilder.Entity<Post>().HasKey(x => x.PostId);
            modelBuilder.Entity<Post>().HasRequired(x => x.Blog)
                                       .WithMany(x => x.Posts)
                                       .HasForeignKey(x => x.BlogId)
                                       .WillCascadeOnDelete(true);





            base.OnModelCreating(modelBuilder);
        }



    }
}