namespace Projecte_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BF1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BBs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreBB = c.String(),
                        BBDesc = c.String(),
                        RamaBBID = c.Int(nullable: false),
                        TipoBBID = c.Int(nullable: false),
                        GrupalBBID = c.Int(nullable: false),
                        NhitsBB = c.Int(nullable: false),
                        DCBB = c.Int(nullable: false),
                        CosteBB = c.Int(nullable: false),
                        MultiplicadorBB = c.Int(nullable: false),
                        PersonajeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GrupalBBs", t => t.GrupalBBID, cascadeDelete: true)
                .ForeignKey("dbo.Personajes", t => t.PersonajeID, cascadeDelete: true)
                .ForeignKey("dbo.RamaBBs", t => t.RamaBBID, cascadeDelete: true)
                .ForeignKey("dbo.TipoBBs", t => t.TipoBBID, cascadeDelete: true)
                .Index(t => t.RamaBBID)
                .Index(t => t.TipoBBID)
                .Index(t => t.GrupalBBID)
                .Index(t => t.PersonajeID);
            
            CreateTable(
                "dbo.Efectos",
                c => new
                    {
                        EfectoID = c.Int(nullable: false, identity: true),
                        AtkUp = c.Int(nullable: false),
                        DefUp = c.Int(nullable: false),
                        RecUp = c.Int(nullable: false),
                        HpUp = c.Int(nullable: false),
                        CritRate = c.Int(nullable: false),
                        CritDmg = c.Int(nullable: false),
                        BBDmg = c.Int(nullable: false),
                        SparkDmg = c.Int(nullable: false),
                        CargaBB = c.Int(nullable: false),
                        CargaBBTurno = c.Int(nullable: false),
                        CargaBBRecibir = c.Int(nullable: false),
                        VelocidadBB = c.Int(nullable: false),
                        CargaBBSpark = c.Int(nullable: false),
                        CargaOD = c.Int(nullable: false),
                        Mitigacion = c.Int(nullable: false),
                        Barrera = c.Int(nullable: false),
                        Heal = c.Int(nullable: false),
                        HealTurno = c.Int(nullable: false),
                        DropCB = c.Int(nullable: false),
                        DropCC = c.Int(nullable: false),
                        DropItems = c.Int(nullable: false),
                        DañoAlAfligir = c.Int(nullable: false),
                        IgnDef = c.Boolean(nullable: false),
                        DoT = c.Int(nullable: false),
                        AumentoHits = c.Int(nullable: false),
                        Revivir = c.Int(nullable: false),
                        BBAtacar = c.Int(nullable: false),
                        BBCritico = c.Int(nullable: false),
                        ReduccionCosteBB = c.Int(nullable: false),
                        ReduccionUsoBB = c.Int(nullable: false),
                        RecargaGuard = c.Int(nullable: false),
                        DropZel = c.Int(nullable: false),
                        DropKarma = c.Int(nullable: false),
                        EfectividadCC = c.Int(nullable: false),
                        ReduccionDmgGuard = c.Int(nullable: false),
                        MitigacionElemental = c.String(),
                        EstadosAlterados = c.String(),
                        Antiestados = c.String(),
                        AtkDown = c.String(),
                        DefDown2 = c.String(),
                        VulnerabilidadSpark = c.String(),
                        AñadirElementos = c.String(),
                        DebilidadElemental = c.String(),
                        Angel = c.String(),
                        ReduccionDaño = c.String(),
                        BBID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EfectoID)
                .ForeignKey("dbo.BBs", t => t.BBID, cascadeDelete: true)
                .Index(t => t.BBID);
            
            CreateTable(
                "dbo.GrupalBBs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreGrupal = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Personajes",
                c => new
                    {
                        Numero = c.Int(nullable: false),
                        Nombre = c.String(),
                        NivelMax = c.Int(nullable: false),
                        Estrellas = c.Int(nullable: false),
                        Coste = c.Int(nullable: false),
                        ElementoID = c.Int(nullable: false),
                        GeneroID = c.Int(nullable: false),
                        NHits = c.Int(nullable: false),
                        DC = c.Int(nullable: false),
                        ImpHP = c.Int(nullable: false),
                        ImpAtk = c.Int(nullable: false),
                        ImpDef = c.Int(nullable: false),
                        ImpRec = c.Int(nullable: false),
                        PreEvoNum = c.Int(),
                        PostEvoNum = c.Int(),
                        ImagenID = c.Int(),
                        IconoID = c.Int(),
                        GifID = c.Int(),
                        GifAtaqueID = c.Int(),
                        Healer = c.Boolean(nullable: false),
                        Mitigador = c.Boolean(nullable: false),
                        Antiestados = c.Boolean(nullable: false),
                        BBFill = c.Boolean(nullable: false),
                        AumentoDrop = c.Boolean(nullable: false),
                        Sparker = c.Boolean(nullable: false),
                        Criticos = c.Boolean(nullable: false),
                        AumentoStats = c.Boolean(nullable: false),
                        Nuker = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Numero)
                .ForeignKey("dbo.Elementoes", t => t.ElementoID, cascadeDelete: true)
                .ForeignKey("dbo.Generoes", t => t.GeneroID, cascadeDelete: true)
                .ForeignKey("dbo.Files", t => t.GifID)
                .ForeignKey("dbo.Files", t => t.GifAtaqueID)
                .ForeignKey("dbo.Files", t => t.IconoID)
                .ForeignKey("dbo.Files", t => t.ImagenID)
                .ForeignKey("dbo.Personajes", t => t.PostEvoNum)
                .ForeignKey("dbo.Personajes", t => t.PreEvoNum)
                .Index(t => t.ElementoID)
                .Index(t => t.GeneroID)
                .Index(t => t.PreEvoNum)
                .Index(t => t.PostEvoNum)
                .Index(t => t.ImagenID)
                .Index(t => t.IconoID)
                .Index(t => t.GifID)
                .Index(t => t.GifAtaqueID);
            
            CreateTable(
                "dbo.Elementoes",
                c => new
                    {
                        ElementoID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DebilVSID = c.Int(),
                        FuerteVSID = c.Int(),
                        IconoID = c.Int(),
                    })
                .PrimaryKey(t => t.ElementoID)
                .ForeignKey("dbo.Elementoes", t => t.DebilVSID)
                .ForeignKey("dbo.Elementoes", t => t.FuerteVSID)
                .ForeignKey("dbo.Files", t => t.IconoID)
                .Index(t => t.DebilVSID)
                .Index(t => t.FuerteVSID)
                .Index(t => t.IconoID);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId);
            
            CreateTable(
                "dbo.Objetoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NomObjeto = c.String(),
                        IconaID = c.Int(),
                        Descripcion = c.String(),
                        TipoID = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Crafteo_Craft = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Crafteos", t => t.Crafteo_Craft)
                .ForeignKey("dbo.Files", t => t.IconaID)
                .ForeignKey("dbo.TipoEsferas", t => t.TipoID, cascadeDelete: true)
                .Index(t => t.IconaID)
                .Index(t => t.TipoID)
                .Index(t => t.Crafteo_Craft);
            
            CreateTable(
                "dbo.Crafteos",
                c => new
                    {
                        Craft = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Craft)
                .ForeignKey("dbo.Objetoes", t => t.Craft)
                .Index(t => t.Craft);
            
            CreateTable(
                "dbo.EfectoEsferas",
                c => new
                    {
                        EfectoID = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(),
                        EsferaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EfectoID)
                .ForeignKey("dbo.Objetoes", t => t.EsferaID, cascadeDelete: true)
                .Index(t => t.EsferaID);
            
            CreateTable(
                "dbo.misEsferas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EsferaID = c.Int(nullable: false),
                        UsuarioID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Objetoes", t => t.EsferaID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioID)
                .Index(t => t.EsferaID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Unidads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PersonajeID = c.Int(nullable: false),
                        TipoID = c.Int(),
                        Esfera1ID = c.Int(),
                        Esfera2ID = c.Int(),
                        UsuarioID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.misEsferas", t => t.Esfera1ID)
                .ForeignKey("dbo.misEsferas", t => t.Esfera2ID)
                .ForeignKey("dbo.Personajes", t => t.PersonajeID, cascadeDelete: true)
                .ForeignKey("dbo.TipoStats", t => t.TipoID)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.PersonajeID)
                .Index(t => t.TipoID)
                .Index(t => t.Esfera1ID)
                .Index(t => t.Esfera2ID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.Equipoes",
                c => new
                    {
                        EquipoID = c.Int(nullable: false, identity: true),
                        Unidad1ID = c.Int(),
                        Unidad2ID = c.Int(),
                        Unidad3ID = c.Int(),
                        Unidad4ID = c.Int(),
                        Unidad5ID = c.Int(),
                        Unidad6ID = c.Int(),
                        UsuarioID = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.EquipoID)
                .ForeignKey("dbo.Unidads", t => t.Unidad1ID)
                .ForeignKey("dbo.Unidads", t => t.Unidad2ID)
                .ForeignKey("dbo.Unidads", t => t.Unidad3ID)
                .ForeignKey("dbo.Unidads", t => t.Unidad4ID)
                .ForeignKey("dbo.Unidads", t => t.Unidad5ID)
                .ForeignKey("dbo.Unidads", t => t.Unidad6ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UsuarioID, cascadeDelete: true)
                .Index(t => t.Unidad1ID)
                .Index(t => t.Unidad2ID)
                .Index(t => t.Unidad3ID)
                .Index(t => t.Unidad4ID)
                .Index(t => t.Unidad5ID)
                .Index(t => t.Unidad6ID)
                .Index(t => t.UsuarioID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Role = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.TipoStats",
                c => new
                    {
                        IDStat = c.Int(nullable: false, identity: true),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.IDStat);
            
            CreateTable(
                "dbo.Stats",
                c => new
                    {
                        StatsID = c.Int(nullable: false, identity: true),
                        PersonajeID = c.Int(nullable: false),
                        TipoPersonajeID = c.Int(nullable: false),
                        Hp = c.Int(nullable: false),
                        Ataque = c.Int(nullable: false),
                        Defensa = c.Int(nullable: false),
                        Recuperacion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StatsID)
                .ForeignKey("dbo.Personajes", t => t.PersonajeID, cascadeDelete: true)
                .ForeignKey("dbo.TipoStats", t => t.TipoPersonajeID, cascadeDelete: true)
                .Index(t => t.PersonajeID)
                .Index(t => t.TipoPersonajeID);
            
            CreateTable(
                "dbo.TipoEsferas",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreTipoEsfera = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ES",
                c => new
                    {
                        ESID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Desc = c.String(),
                        PersonajeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ESID)
                .ForeignKey("dbo.Personajes", t => t.PersonajeID, cascadeDelete: true)
                .Index(t => t.PersonajeID);
            
            CreateTable(
                "dbo.Generoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreGenero = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LS",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Desc = c.String(),
                        PersonajeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Personajes", t => t.PersonajeID, cascadeDelete: true)
                .Index(t => t.PersonajeID);
            
            CreateTable(
                "dbo.RamaBBs",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreRamaBB = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.TipoBBs",
                c => new
                    {
                        TipoID = c.Int(nullable: false, identity: true),
                        NombreTipoBB = c.String(),
                    })
                .PrimaryKey(t => t.TipoID);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.BBs", "TipoBBID", "dbo.TipoBBs");
            DropForeignKey("dbo.BBs", "RamaBBID", "dbo.RamaBBs");
            DropForeignKey("dbo.BBs", "PersonajeID", "dbo.Personajes");
            DropForeignKey("dbo.Personajes", "PreEvoNum", "dbo.Personajes");
            DropForeignKey("dbo.Personajes", "PostEvoNum", "dbo.Personajes");
            DropForeignKey("dbo.LS", "PersonajeID", "dbo.Personajes");
            DropForeignKey("dbo.Personajes", "ImagenID", "dbo.Files");
            DropForeignKey("dbo.Personajes", "IconoID", "dbo.Files");
            DropForeignKey("dbo.Personajes", "GifAtaqueID", "dbo.Files");
            DropForeignKey("dbo.Personajes", "GifID", "dbo.Files");
            DropForeignKey("dbo.Personajes", "GeneroID", "dbo.Generoes");
            DropForeignKey("dbo.ES", "PersonajeID", "dbo.Personajes");
            DropForeignKey("dbo.Personajes", "ElementoID", "dbo.Elementoes");
            DropForeignKey("dbo.Elementoes", "IconoID", "dbo.Files");
            DropForeignKey("dbo.Objetoes", "TipoID", "dbo.TipoEsferas");
            DropForeignKey("dbo.Unidads", "UsuarioID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Unidads", "TipoID", "dbo.TipoStats");
            DropForeignKey("dbo.Stats", "TipoPersonajeID", "dbo.TipoStats");
            DropForeignKey("dbo.Stats", "PersonajeID", "dbo.Personajes");
            DropForeignKey("dbo.Unidads", "PersonajeID", "dbo.Personajes");
            DropForeignKey("dbo.Unidads", "Esfera2ID", "dbo.misEsferas");
            DropForeignKey("dbo.Unidads", "Esfera1ID", "dbo.misEsferas");
            DropForeignKey("dbo.Equipoes", "UsuarioID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.misEsferas", "UsuarioID", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Equipoes", "Unidad6ID", "dbo.Unidads");
            DropForeignKey("dbo.Equipoes", "Unidad5ID", "dbo.Unidads");
            DropForeignKey("dbo.Equipoes", "Unidad4ID", "dbo.Unidads");
            DropForeignKey("dbo.Equipoes", "Unidad3ID", "dbo.Unidads");
            DropForeignKey("dbo.Equipoes", "Unidad2ID", "dbo.Unidads");
            DropForeignKey("dbo.Equipoes", "Unidad1ID", "dbo.Unidads");
            DropForeignKey("dbo.misEsferas", "EsferaID", "dbo.Objetoes");
            DropForeignKey("dbo.EfectoEsferas", "EsferaID", "dbo.Objetoes");
            DropForeignKey("dbo.Objetoes", "IconaID", "dbo.Files");
            DropForeignKey("dbo.Objetoes", "Crafteo_Craft", "dbo.Crafteos");
            DropForeignKey("dbo.Crafteos", "Craft", "dbo.Objetoes");
            DropForeignKey("dbo.Elementoes", "FuerteVSID", "dbo.Elementoes");
            DropForeignKey("dbo.Elementoes", "DebilVSID", "dbo.Elementoes");
            DropForeignKey("dbo.BBs", "GrupalBBID", "dbo.GrupalBBs");
            DropForeignKey("dbo.Efectos", "BBID", "dbo.BBs");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.LS", new[] { "PersonajeID" });
            DropIndex("dbo.ES", new[] { "PersonajeID" });
            DropIndex("dbo.Stats", new[] { "TipoPersonajeID" });
            DropIndex("dbo.Stats", new[] { "PersonajeID" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Equipoes", new[] { "UsuarioID" });
            DropIndex("dbo.Equipoes", new[] { "Unidad6ID" });
            DropIndex("dbo.Equipoes", new[] { "Unidad5ID" });
            DropIndex("dbo.Equipoes", new[] { "Unidad4ID" });
            DropIndex("dbo.Equipoes", new[] { "Unidad3ID" });
            DropIndex("dbo.Equipoes", new[] { "Unidad2ID" });
            DropIndex("dbo.Equipoes", new[] { "Unidad1ID" });
            DropIndex("dbo.Unidads", new[] { "UsuarioID" });
            DropIndex("dbo.Unidads", new[] { "Esfera2ID" });
            DropIndex("dbo.Unidads", new[] { "Esfera1ID" });
            DropIndex("dbo.Unidads", new[] { "TipoID" });
            DropIndex("dbo.Unidads", new[] { "PersonajeID" });
            DropIndex("dbo.misEsferas", new[] { "UsuarioID" });
            DropIndex("dbo.misEsferas", new[] { "EsferaID" });
            DropIndex("dbo.EfectoEsferas", new[] { "EsferaID" });
            DropIndex("dbo.Crafteos", new[] { "Craft" });
            DropIndex("dbo.Objetoes", new[] { "Crafteo_Craft" });
            DropIndex("dbo.Objetoes", new[] { "TipoID" });
            DropIndex("dbo.Objetoes", new[] { "IconaID" });
            DropIndex("dbo.Elementoes", new[] { "IconoID" });
            DropIndex("dbo.Elementoes", new[] { "FuerteVSID" });
            DropIndex("dbo.Elementoes", new[] { "DebilVSID" });
            DropIndex("dbo.Personajes", new[] { "GifAtaqueID" });
            DropIndex("dbo.Personajes", new[] { "GifID" });
            DropIndex("dbo.Personajes", new[] { "IconoID" });
            DropIndex("dbo.Personajes", new[] { "ImagenID" });
            DropIndex("dbo.Personajes", new[] { "PostEvoNum" });
            DropIndex("dbo.Personajes", new[] { "PreEvoNum" });
            DropIndex("dbo.Personajes", new[] { "GeneroID" });
            DropIndex("dbo.Personajes", new[] { "ElementoID" });
            DropIndex("dbo.Efectos", new[] { "BBID" });
            DropIndex("dbo.BBs", new[] { "PersonajeID" });
            DropIndex("dbo.BBs", new[] { "GrupalBBID" });
            DropIndex("dbo.BBs", new[] { "TipoBBID" });
            DropIndex("dbo.BBs", new[] { "RamaBBID" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.TipoBBs");
            DropTable("dbo.RamaBBs");
            DropTable("dbo.LS");
            DropTable("dbo.Generoes");
            DropTable("dbo.ES");
            DropTable("dbo.TipoEsferas");
            DropTable("dbo.Stats");
            DropTable("dbo.TipoStats");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Equipoes");
            DropTable("dbo.Unidads");
            DropTable("dbo.misEsferas");
            DropTable("dbo.EfectoEsferas");
            DropTable("dbo.Crafteos");
            DropTable("dbo.Objetoes");
            DropTable("dbo.Files");
            DropTable("dbo.Elementoes");
            DropTable("dbo.Personajes");
            DropTable("dbo.GrupalBBs");
            DropTable("dbo.Efectos");
            DropTable("dbo.BBs");
        }
    }
}
