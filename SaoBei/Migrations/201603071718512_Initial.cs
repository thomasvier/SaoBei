namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Integrantes", "Nome", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Integrantes", "Nome", c => c.String());
        }
    }
}
