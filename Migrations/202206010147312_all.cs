namespace AplicationEPAC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class all : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enrolments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        Date = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        type = c.Int(nullable: false),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Evaluations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        Announcement = c.Int(nullable: false),
                        AvgTheoryMark = c.Decimal(precision: 18, scale: 2),
                        AvgPracticalMark = c.Decimal(precision: 18, scale: 2),
                        FinalMark = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.TeachingAssignments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.CourseId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeachingAssignments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.TeachingAssignments", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.TeachingAssignments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Evaluations", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Evaluations", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Evaluations", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrolments", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Enrolments", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Enrolments", "CourseId", "dbo.Courses");
            DropIndex("dbo.TeachingAssignments", new[] { "GroupId" });
            DropIndex("dbo.TeachingAssignments", new[] { "CourseId" });
            DropIndex("dbo.TeachingAssignments", new[] { "UserId" });
            DropIndex("dbo.Evaluations", new[] { "GroupId" });
            DropIndex("dbo.Evaluations", new[] { "CourseId" });
            DropIndex("dbo.Evaluations", new[] { "UserId" });
            DropIndex("dbo.Enrolments", new[] { "GroupId" });
            DropIndex("dbo.Enrolments", new[] { "CourseId" });
            DropIndex("dbo.Enrolments", new[] { "UserId" });
            DropTable("dbo.TeachingAssignments");
            DropTable("dbo.Evaluations");
            DropTable("dbo.Groups");
            DropTable("dbo.Enrolments");
            DropTable("dbo.Courses");
        }
    }
}
