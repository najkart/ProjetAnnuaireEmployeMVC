namespace AnnuaireEmploye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationEmailDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employes", "Email", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employes", "Email", c => c.String());
        }
    }
}
