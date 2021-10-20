namespace UINProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cohortes",
                c => new
                    {
                        IdCohorte = c.Int(nullable: false, identity: true),
                        NombreCohorte = c.String(nullable: false),
                        IdYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdCohorte)
                .ForeignKey("dbo.Years", t => t.IdYear, cascadeDelete: true)
                .Index(t => t.IdYear);
            
            CreateTable(
                "dbo.Estudiantes",
                c => new
                    {
                        IdEstudiante = c.Int(nullable: false, identity: true),
                        NombreEstudiante = c.String(nullable: false),
                        CarnetEstudiante = c.String(nullable: false),
                        EdadEstudiante = c.Int(nullable: false),
                        TelefonoEstudiante = c.Int(nullable: false),
                        CorreoEstudiante = c.String(nullable: false),
                        IdDireccion = c.Int(nullable: false),
                        IdCohorte = c.Int(nullable: false),
                        IdEspecialidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEstudiante)
                .ForeignKey("dbo.Cohortes", t => t.IdCohorte, cascadeDelete: true)
                .Index(t => t.IdCohorte);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        IdYear = c.Int(nullable: false, identity: true),
                        NombreYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdYear);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cohortes", "IdYear", "dbo.Years");
            DropForeignKey("dbo.Estudiantes", "IdCohorte", "dbo.Cohortes");
            DropIndex("dbo.Estudiantes", new[] { "IdCohorte" });
            DropIndex("dbo.Cohortes", new[] { "IdYear" });
            DropTable("dbo.Years");
            DropTable("dbo.Estudiantes");
            DropTable("dbo.Cohortes");
        }
    }
}
