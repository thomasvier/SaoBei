namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Calendario : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Calendarios", "ValorAnuidade", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Calendarios", "ValorAnuidade");
        }
    }
}
