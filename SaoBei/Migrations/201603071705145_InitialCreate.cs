namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ano = c.Int(nullable: false),
                        Janeiro = c.Boolean(nullable: false),
                        Fevereiro = c.Boolean(nullable: false),
                        Marco = c.Boolean(nullable: false),
                        Abril = c.Boolean(nullable: false),
                        Maio = c.Boolean(nullable: false),
                        Junho = c.Boolean(nullable: false),
                        Julho = c.Boolean(nullable: false),
                        Agosto = c.Boolean(nullable: false),
                        Setembro = c.Boolean(nullable: false),
                        Outubro = c.Boolean(nullable: false),
                        Novembro = c.Boolean(nullable: false),
                        Dezembro = c.Boolean(nullable: false),
                        ValorMensalidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Integrantes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Integrantes");
            DropTable("dbo.Calendarios");
        }
    }
}
