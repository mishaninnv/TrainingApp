namespace BusinessLogic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewParameters : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MuscleGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Exercises", "Description", c => c.String());
            AddColumn("dbo.Exercises", "MuscleGroup_Id", c => c.Int());
            AddColumn("dbo.Trainings", "Description", c => c.String());
            CreateIndex("dbo.Exercises", "MuscleGroup_Id");
            AddForeignKey("dbo.Exercises", "MuscleGroup_Id", "dbo.MuscleGroups", "Id");
            DropColumn("dbo.Exercises", "Text");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Exercises", "Text", c => c.String());
            DropForeignKey("dbo.Exercises", "MuscleGroup_Id", "dbo.MuscleGroups");
            DropIndex("dbo.Exercises", new[] { "MuscleGroup_Id" });
            DropColumn("dbo.Trainings", "Description");
            DropColumn("dbo.Exercises", "MuscleGroup_Id");
            DropColumn("dbo.Exercises", "Description");
            DropTable("dbo.MuscleGroups");
        }
    }
}
