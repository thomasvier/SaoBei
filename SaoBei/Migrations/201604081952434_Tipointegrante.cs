namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Tipointegrante : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Integrantes", "TipoIntegrante", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Integrantes", "TipoIntegrante");
        }
    }
}
