namespace UINProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tablas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        IdDireccion = c.Int(nullable: false, identity: true),
                        NombreDepartamento = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.IdDireccion);
            
            CreateTable(
                "dbo.Especialidades",
                c => new
                    {
                        IdEspecialidad = c.Int(nullable: false, identity: true),
                        NombreEspecialidad = c.String(nullable: false),
                        IdEspecialidades = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdEspecialidad);
            
            AddColumn("dbo.Estudiantes", "IdDireccion", c => c.Int());
            AddColumn("dbo.Estudiantes", "IdEspecialidad", c => c.Int());
            CreateIndex("dbo.Estudiantes", "IdDireccion");
            CreateIndex("dbo.Estudiantes", "IdEspecialidad");
            AddForeignKey("dbo.Estudiantes", "IdDireccion", "dbo.Departamentos", "IdDireccion");
            AddForeignKey("dbo.Estudiantes", "IdEspecialidad", "dbo.Especialidades", "IdEspecialidad");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Estudiantes", "IdEspecialidad", "dbo.Especialidades");
            DropForeignKey("dbo.Estudiantes", "IdDireccion", "dbo.Departamentos");
            DropIndex("dbo.Estudiantes", new[] { "IdEspecialidad" });
            DropIndex("dbo.Estudiantes", new[] { "IdDireccion" });
            DropColumn("dbo.Estudiantes", "IdEspecialidad");
            DropColumn("dbo.Estudiantes", "IdDireccion");
            DropTable("dbo.Especialidades");
            DropTable("dbo.Departamentos");
        }
    }
}
