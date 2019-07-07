namespace AnnuaireEmploye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationTel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employes", "Telephone", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employes", "Telephone", c => c.String());
        }
    }
}
