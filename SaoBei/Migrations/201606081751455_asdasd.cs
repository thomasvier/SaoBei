namespace SaoBei.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdasd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Integrantes", "Senha", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Integrantes", "Senha", c => c.String());
        }
    }
}
