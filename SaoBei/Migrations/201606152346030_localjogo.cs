namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class localjogo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LocalJogo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(maxLength: 300),
                        ValorJogo = c.Decimal(precision: 18, scale: 2),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LocalJogo");
        }
    }
}
