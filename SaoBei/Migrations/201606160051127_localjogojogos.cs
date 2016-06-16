namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class localjogojogos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jogo", "LocalJogoID", c => c.Int(nullable: false));
            CreateIndex("dbo.Jogo", "LocalJogoID");
            AddForeignKey("dbo.Jogo", "LocalJogoID", "dbo.LocalJogo", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jogo", "LocalJogoID", "dbo.LocalJogo");
            DropIndex("dbo.Jogo", new[] { "LocalJogoID" });
            DropColumn("dbo.Jogo", "LocalJogoID");
        }
    }
}
