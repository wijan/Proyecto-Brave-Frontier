namespace Projecte_Final.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BF2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Personajes", "IAArena", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Personajes", "IAArena");
        }
    }
}
