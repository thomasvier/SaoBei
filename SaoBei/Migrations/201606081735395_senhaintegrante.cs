namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class senhaintegrante : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Mensalidades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
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
                        Anuidade = c.Boolean(nullable: false),
                        CalendarioID = c.Int(nullable: false),
                        IntegrandeID = c.Int(nullable: false),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Calendarios", t => t.CalendarioID, cascadeDelete: true)
                .ForeignKey("dbo.Integrantes", t => t.IntegrandeID, cascadeDelete: true)
                .Index(t => t.CalendarioID)
                .Index(t => t.IntegrandeID);
            
            AddColumn("dbo.Integrantes", "Senha", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensalidades", "IntegrandeID", "dbo.Integrantes");
            DropForeignKey("dbo.Mensalidades", "CalendarioID", "dbo.Calendarios");
            DropIndex("dbo.Mensalidades", new[] { "IntegrandeID" });
            DropIndex("dbo.Mensalidades", new[] { "CalendarioID" });
            DropColumn("dbo.Integrantes", "Senha");
            DropTable("dbo.Mensalidades");
        }
    }
}
