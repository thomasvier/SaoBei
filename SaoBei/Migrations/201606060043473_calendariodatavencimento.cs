namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class calendariodatavencimento : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendarios", "DataVencimentoAnuidade", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calendarios", "DataVencimentoAnuidade");
        }
    }
}
