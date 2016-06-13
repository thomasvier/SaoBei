namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datahora : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jogo", "Hora", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jogo", "Hora");
        }
    }
}
