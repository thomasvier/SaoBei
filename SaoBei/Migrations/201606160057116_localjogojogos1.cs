namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class localjogojogos1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Jogo", "Local");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Jogo", "Local", c => c.String(nullable: false));
        }
    }
}
