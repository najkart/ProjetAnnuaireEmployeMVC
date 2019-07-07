namespace AnnuaireEmploye.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateClasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departements",
                c => new
                    {
                        IdDepartement = c.Int(nullable: false, identity: true),
                        NomDepartement = c.String(),
                    })
                .PrimaryKey(t => t.IdDepartement);
            
            CreateTable(
                "dbo.Employes",
                c => new
                    {
                        IdEmploye = c.Int(nullable: false, identity: true),
                        Matricule = c.String(),
                        NomComplet = c.String(),
                        DateEmbauche = c.DateTime(nullable: false),
                        IdPoste = c.Int(nullable: false),
                        IdDepartement = c.Int(nullable: false),
                        Actif = c.Boolean(nullable: false),
                        Email = c.String(),
                        Telephone = c.String(),
                    })
                .PrimaryKey(t => t.IdEmploye)
                .ForeignKey("dbo.Departements", t => t.IdDepartement, cascadeDelete: true)
                .ForeignKey("dbo.Postes", t => t.IdPoste, cascadeDelete: true)
                .Index(t => t.IdPoste)
                .Index(t => t.IdDepartement);
            
            CreateTable(
                "dbo.Postes",
                c => new
                    {
                        IdPoste = c.Int(nullable: false, identity: true),
                        NomPoste = c.String(),
                    })
                .PrimaryKey(t => t.IdPoste);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employes", "IdPoste", "dbo.Postes");
            DropForeignKey("dbo.Employes", "IdDepartement", "dbo.Departements");
            DropIndex("dbo.Employes", new[] { "IdDepartement" });
            DropIndex("dbo.Employes", new[] { "IdPoste" });
            DropTable("dbo.Postes");
            DropTable("dbo.Employes");
            DropTable("dbo.Departements");
        }
    }
}
