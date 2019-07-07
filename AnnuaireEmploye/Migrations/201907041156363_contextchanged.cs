namespace AnnuaireEmploye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contextchanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employes", "Ville", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employes", "Ville", c => c.String(nullable: false));
        }
    }
}
