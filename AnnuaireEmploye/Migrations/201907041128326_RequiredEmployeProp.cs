namespace AnnuaireEmploye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredEmployeProp : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employes", "Matricule", c => c.String(nullable: false));
            AlterColumn("dbo.Employes", "NomComplet", c => c.String(nullable: false));
            AlterColumn("dbo.Employes", "Ville", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employes", "Ville", c => c.String());
            AlterColumn("dbo.Employes", "NomComplet", c => c.String());
            AlterColumn("dbo.Employes", "Matricule", c => c.String());
        }
    }
}
