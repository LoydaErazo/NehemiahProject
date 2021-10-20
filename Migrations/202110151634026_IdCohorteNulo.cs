namespace UINProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IdCohorteNulo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Estudiantes", "IdCohorte", "dbo.Cohortes");
            DropIndex("dbo.Estudiantes", new[] { "IdCohorte" });
            AlterColumn("dbo.Estudiantes", "IdCohorte", c => c.Int());
            CreateIndex("dbo.Estudiantes", "IdCohorte");
            AddForeignKey("dbo.Estudiantes", "IdCohorte", "dbo.Cohortes", "IdCohorte");
            DropColumn("dbo.Estudiantes", "IdDireccion");
            DropColumn("dbo.Estudiantes", "IdEspecialidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Estudiantes", "IdEspecialidad", c => c.Int(nullable: false));
            AddColumn("dbo.Estudiantes", "IdDireccion", c => c.Int(nullable: false));
            DropForeignKey("dbo.Estudiantes", "IdCohorte", "dbo.Cohortes");
            DropIndex("dbo.Estudiantes", new[] { "IdCohorte" });
            AlterColumn("dbo.Estudiantes", "IdCohorte", c => c.Int(nullable: false));
            CreateIndex("dbo.Estudiantes", "IdCohorte");
            AddForeignKey("dbo.Estudiantes", "IdCohorte", "dbo.Cohortes", "IdCohorte", cascadeDelete: true);
        }
    }
}
