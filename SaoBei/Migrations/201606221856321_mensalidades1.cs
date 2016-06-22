namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mensalidades1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Mensalidades", "CalendarioID", "dbo.Calendario");
            DropForeignKey("dbo.Mensalidades", "IntegrandeID", "dbo.Integrante");
            DropIndex("dbo.Mensalidades", new[] { "CalendarioID" });
            DropIndex("dbo.Mensalidades", new[] { "IntegrandeID" });
            CreateTable(
                "dbo.MensalidadeIntegrante",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Mes = c.Int(nullable: false),
                        CalendarioID = c.Int(nullable: false),
                        IntegranteID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Calendario", t => t.CalendarioID, cascadeDelete: true)
                .ForeignKey("dbo.Integrante", t => t.IntegranteID, cascadeDelete: true)
                .Index(t => t.CalendarioID)
                .Index(t => t.IntegranteID);
            
            DropTable("dbo.Mensalidades");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.MensalidadeIntegrante", "IntegranteID", "dbo.Integrante");
            DropForeignKey("dbo.MensalidadeIntegrante", "CalendarioID", "dbo.Calendario");
            DropIndex("dbo.MensalidadeIntegrante", new[] { "IntegranteID" });
            DropIndex("dbo.MensalidadeIntegrante", new[] { "CalendarioID" });
            DropTable("dbo.MensalidadeIntegrante");
            CreateIndex("dbo.Mensalidades", "IntegrandeID");
            CreateIndex("dbo.Mensalidades", "CalendarioID");
            AddForeignKey("dbo.Mensalidades", "IntegrandeID", "dbo.Integrante", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Mensalidades", "CalendarioID", "dbo.Calendario", "ID", cascadeDelete: true);
        }
    }
}
