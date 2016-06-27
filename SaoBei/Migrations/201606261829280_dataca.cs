namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataca : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MensalidadeIntegrante", "DataPagamento", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MensalidadeIntegrante", "DataPagamento", c => c.DateTime());
        }
    }
}
