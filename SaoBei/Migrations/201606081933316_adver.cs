namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adver : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adversarios",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        NomeContato = c.String(),
                        Telefone = c.String(),
                        Ativo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Adversarios");
        }
    }
}
