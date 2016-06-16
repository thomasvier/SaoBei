namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adversario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        NomeContato = c.String(),
                        Telefone = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Calendario",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Ano = c.Int(nullable: false),
                        DataVencimentoAnuidade = c.DateTime(nullable: false),
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
                        ValorAnuidade = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Integrante",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Telefone = c.String(),
                        DataNascimento = c.DateTime(nullable: false),
                        Email = c.String(),
                        TipoIntegrante = c.Int(nullable: false),
                        Senha = c.String(maxLength: 20),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Jogo",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Data = c.DateTime(nullable: false),
                        Hora = c.DateTime(nullable: false),
                        AdversarioID = c.Int(nullable: false),
                        CalendarioID = c.Int(nullable: false),
                        SituacaoJogo = c.Int(nullable: false),
                        MotivoCancelamento = c.String(),
                        LocalJogoID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Adversario", t => t.AdversarioID, cascadeDelete: true)
                .ForeignKey("dbo.Calendario", t => t.CalendarioID, cascadeDelete: true)
                .ForeignKey("dbo.LocalJogo", t => t.LocalJogoID, cascadeDelete: true)
                .Index(t => t.AdversarioID)
                .Index(t => t.CalendarioID)
                .Index(t => t.LocalJogoID);
            
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
            
            CreateTable(
                "dbo.Log",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TipoLog = c.Int(nullable: false),
                        Mensagem = c.String(nullable: false),
                        Observacao = c.String(),
                        Usuario = c.String(),
                        DataHora = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
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
                .ForeignKey("dbo.Calendario", t => t.CalendarioID, cascadeDelete: true)
                .ForeignKey("dbo.Integrante", t => t.IntegrandeID, cascadeDelete: true)
                .Index(t => t.CalendarioID)
                .Index(t => t.IntegrandeID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Mensalidades", "IntegrandeID", "dbo.Integrante");
            DropForeignKey("dbo.Mensalidades", "CalendarioID", "dbo.Calendario");
            DropForeignKey("dbo.Jogo", "LocalJogoID", "dbo.LocalJogo");
            DropForeignKey("dbo.Jogo", "CalendarioID", "dbo.Calendario");
            DropForeignKey("dbo.Jogo", "AdversarioID", "dbo.Adversario");
            DropIndex("dbo.Mensalidades", new[] { "IntegrandeID" });
            DropIndex("dbo.Mensalidades", new[] { "CalendarioID" });
            DropIndex("dbo.Jogo", new[] { "LocalJogoID" });
            DropIndex("dbo.Jogo", new[] { "CalendarioID" });
            DropIndex("dbo.Jogo", new[] { "AdversarioID" });
            DropTable("dbo.Mensalidades");
            DropTable("dbo.Log");
            DropTable("dbo.LocalJogo");
            DropTable("dbo.Jogo");
            DropTable("dbo.Integrante");
            DropTable("dbo.Calendario");
            DropTable("dbo.Adversario");
        }
    }
}
