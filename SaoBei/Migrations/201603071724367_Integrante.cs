namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Integrante : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Integrantes", "Telefone", c => c.String());
            AddColumn("dbo.Integrantes", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Integrantes", "Email");
            DropColumn("dbo.Integrantes", "Telefone");
        }
    }
}
