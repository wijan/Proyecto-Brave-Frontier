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
        public enum RoleNum
        {
            Normal= 1,
            Admin=2,
            Root=3
        }
        public RoleNum Role { get; set; } = RoleNum.Normal;


        public virtual List<Equipo> Equips { get; set; }
        public virtual List<Unidad> Unidades { get; set; }
        public virtual List<misEsferas> misEsferas { get; set; }

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
        public DbSet<Crafteo> Crafteo { get; set; }
        public DbSet<EfectoEsfera> EfectoEsfera { get; set; }
        public DbSet<Efectos> Efectos { get; set; }
        public DbSet<Elemento> Elemento { get; set; }
        public DbSet<Equipo> Equipo { get; set; }
        public DbSet<ES> ES { get; set; }
        public DbSet<Esfera> Esfera { get; set; }
        public DbSet<File> File { get; set; }
        public DbSet<Genero> Genero { get; set; }
        public DbSet<GrupalBB> GrupalBB { get; set; }
        public DbSet<LS> LS { get; set; }
        public DbSet<Objeto> Objeto { get; set; }
        public DbSet<Personaje> Personaje { get; set; }
        public DbSet<RamaBB> RamaBB { get; set; }
        public DbSet<Stats> Stats { get; set; }
        public DbSet<TipoBB> TipoBB { get; set; }
        public DbSet<TipoEsfera> TipoEsfera { get; set; }
        public DbSet<Unidad> Unidad { get; set; }
        public DbSet<misEsferas> misEsferas { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {


            ////ES
            //modelBuilder.Entity<ES>().HasKey(x => x.ID);
            modelBuilder.Entity<ES>().HasRequired(x => x.Personaje).WithMany(x => x.ES).HasForeignKey(x => x.PersonajeID);

            ////LS
            modelBuilder.Entity<LS>().HasRequired(x => x.Personaje).WithMany(x => x.LS).HasForeignKey(x => x.PersonajeID);

            //RamaBB
            //modelBuilder.Entity<RamaBB>().HasKey(x => x.ID);

            ////TipoBB
            //modelBuilder.Entity<TipoBB>().HasKey(x => x.TipoID);

            ////GrupalBB
            //modelBuilder.Entity<GrupalBB>().HasKey(x => x.ID);

            ////Efectos
            //modelBuilder.Entity<Efectos>().HasKey(x => x.EfectoBBID);
            modelBuilder.Entity<Efectos>().HasRequired(x => x.BB).WithMany(x => x.Efectos).HasForeignKey(x => x.BBID);

            ////Genero
            //modelBuilder.Entity<Genero>().HasKey(x => x.ID);


            ////EfectoEsfera
            //modelBuilder.Entity<EfectoEsfera>().HasKey(x => x.EfectoID);
            modelBuilder.Entity<EfectoEsfera>().HasRequired(x => x.Esfera).WithMany(x => x.EfectosEsfera).HasForeignKey(x => x.EsferaID);

            ////TipoEsfera
            //modelBuilder.Entity<TipoEsfera>().HasKey(x => x.ID);

            ////BB
            //modelBuilder.Entity<BB>().HasKey(x => x.ID);
            modelBuilder.Entity<BB>().HasRequired(x => x.RamaBB).WithMany(x => x.BBRama).HasForeignKey(x => x.RamaBBID);
            modelBuilder.Entity<BB>().HasRequired(x => x.TipoBB).WithMany(x => x.BBTipo).HasForeignKey(x => x.TipoBBID);
            modelBuilder.Entity<BB>().HasRequired(x => x.GrupalBB).WithMany(x => x.BBGrupal).HasForeignKey(x => x.GrupalBBID);
            modelBuilder.Entity<BB>().HasRequired(x => x.Personaje).WithMany(x => x.BBs).HasForeignKey(x => x.PersonajeID);

            //misEsferas
            modelBuilder.Entity<misEsferas>().HasRequired(x => x.Esfera).WithMany(x => x.misEsferas).HasForeignKey(x => x.EsferaID);
            modelBuilder.Entity<Equipo>().HasRequired(x => x.Usuario).WithMany(x => x.Equips).HasForeignKey(x => x.UsuarioID);

            //Elemento
            //modelBuilder.Entity<Elemento>().HasKey(x => x.ID);
            modelBuilder.Entity<Elemento>().HasOptional(x => x.DebilVS).WithMany(x => x.SoyFuerteContra).HasForeignKey(x => x.DebilVSID);
            modelBuilder.Entity<Elemento>().HasOptional(x => x.FuerteVS).WithMany(x => x.SoyDebilContra).HasForeignKey(x => x.FuerteVSID);
            modelBuilder.Entity<Elemento>().HasOptional(x => x.Icono).WithMany(x => x.Elementos).HasForeignKey(x => x.IconoID); 


            ////Personaje
            //modelBuilder.Entity<Personaje>().HasKey(x => x.Numero);

            modelBuilder.Entity<Personaje>().HasRequired(x => x.Elemento).WithMany(x => x.Personajes).HasForeignKey(x => x.ElementoID);
            modelBuilder.Entity<Personaje>().HasRequired(x => x.Genero).WithMany(x => x.Personajes).HasForeignKey(x => x.GeneroID);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.PreEvo).WithMany(x => x.PersonajesPre).HasForeignKey(x => x.PreEvoNum);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.PostEvo).WithMany(x => x.PersonajesPost).HasForeignKey(x => x.PostEvoNum);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.Icono).WithMany(x => x.PersonajesIcono).HasForeignKey(x => x.IconoID);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.Imagen).WithMany(x => x.PersonajesImagen).HasForeignKey(x => x.ImagenID);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.Gif).WithMany(x => x.PersonajesGif).HasForeignKey(x => x.GifID);
            modelBuilder.Entity<Personaje>().HasOptional(x => x.GifAtaque).WithMany(x => x.PersonajesGifAtaque).HasForeignKey(x => x.GifAtaqueID);

            ////Crafteo
            //modelBuilder.Entity<Crafteo>().HasKey(x => x.ID);
            modelBuilder.Entity<Crafteo>().HasRequired(x => x.Objeto).WithOptional(x => x.Crafteo);


            ////Objeto
            //modelBuilder.Entity<Objeto>().HasKey(x => x.ID);
            modelBuilder.Entity<Objeto>().HasOptional(x => x.Crafteo);
            modelBuilder.Entity<Objeto>().HasOptional(x => x.Icona).WithMany(x => x.Objetos).HasForeignKey(x => x.IconaID);


            ////Esfera
            //modelBuilder.Entity<Esfera>().HasKey(x => x.ID);
            modelBuilder.Entity<Esfera>().HasOptional(x => x.Crafteo);
            modelBuilder.Entity<Esfera>().HasRequired(x => x.TipoEsfera).WithMany(x => x.Esferas).HasForeignKey(x => x.TipoID);

            ////Stats
            //modelBuilder.Entity<Stats>().HasKey(x => x.ID);
            modelBuilder.Entity<Stats>().HasRequired(x => x.Personaje).WithMany(x => x.Stats).HasForeignKey(x => x.PersonajeID);
            modelBuilder.Entity<Stats>().HasRequired(x => x.TipoPersonaje).WithMany(x => x.Stats).HasForeignKey(x => x.TipoPersonajeID);

            ////Unidad
            //modelBuilder.Entity<Unidad>().HasKey(x => x.ID);
            modelBuilder.Entity<Unidad>().HasRequired(x => x.Personaje).WithMany(x => x.Unidades).HasForeignKey(x => x.PersonajeID);
            modelBuilder.Entity<Unidad>().HasOptional(x => x.Tipo).WithMany(x => x.Unidades).HasForeignKey(x => x.TipoID);
            modelBuilder.Entity<Unidad>().HasOptional(x => x.Esfera1).WithMany(x => x.Unidades1).HasForeignKey(x => x.Esfera1ID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Unidad>().HasOptional(x => x.Esfera2).WithMany(x => x.Unidades2).HasForeignKey(x => x.Esfera2ID).WillCascadeOnDelete(false);
            modelBuilder.Entity<Unidad>().HasRequired(x => x.Usuario).WithMany(x => x.Unidades).HasForeignKey(x => x.UsuarioID);

            ////Equipo
            //modelBuilder.Entity<Equipo>().HasKey(x => x.ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad1).WithMany(x => x.EquiposUnidad1).HasForeignKey(x => x.Unidad1ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad2).WithMany(x => x.EquiposUnidad2).HasForeignKey(x => x.Unidad2ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad3).WithMany(x => x.EquiposUnidad3).HasForeignKey(x => x.Unidad3ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad4).WithMany(x => x.EquiposUnidad4).HasForeignKey(x => x.Unidad4ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad5).WithMany(x => x.EquiposUnidad5).HasForeignKey(x => x.Unidad5ID);
            modelBuilder.Entity<Equipo>().HasOptional(x => x.Unidad6).WithMany(x => x.EquiposUnidad6).HasForeignKey(x => x.Unidad6ID);
            modelBuilder.Entity<Equipo>().HasRequired(x => x.Usuario).WithMany(x => x.Equips).HasForeignKey(x => x.UsuarioID);

            //-----------------------
            
            ////Configure domain classes using modelBuilder here
            
            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<Projecte_Final.Models.TipoStat> TipoStats { get; set; }
    }
}