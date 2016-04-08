namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Aniversario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Integrantes", "DataNascimento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Integrantes", "DataNascimento");
        }
    }
}
