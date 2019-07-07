namespace AnnuaireEmploye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPropCity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employes", "Ville", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employes", "Ville");
        }
    }
}
