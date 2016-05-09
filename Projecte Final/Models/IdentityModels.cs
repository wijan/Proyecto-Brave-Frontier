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