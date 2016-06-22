namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datapagamentomensalidade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MensalidadeIntegrante", "DataPagamento", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MensalidadeIntegrante", "DataPagamento");
        }
    }
}
