namespace JobPortal.App.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changestructure : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EducationBackgrounds", "Resume_ID", "dbo.Resumes");
            DropForeignKey("dbo.Languages", "ResumeId", "dbo.Resumes");
            DropForeignKey("dbo.WorkExperiences", "ResumeId", "dbo.Resumes");
            DropForeignKey("dbo.Users", "Resume_ID", "dbo.Resumes");
            DropIndex("dbo.EducationBackgrounds", new[] { "Resume_ID" });
            DropIndex("dbo.Languages", new[] { "ResumeId" });
            DropIndex("dbo.WorkExperiences", new[] { "ResumeId" });
            DropIndex("dbo.Users", new[] { "Resume_ID" });
            DropIndex("dbo.JobApplications", new[] { "user_Id" });
            CreateTable(
                "dbo.JobCategories",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.JobSeekers",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserID = c.String(maxLength: 128),
                        FullName = c.String(maxLength: 100),
                        AdditionalInformation = c.String(),
                        ProfileImageUri = c.String(),
                        CareerObjective = c.String(),
                        SkillsAndQualifications = c.String(),
                        FirstName = c.String(maxLength: 25),
                        LastName = c.String(maxLength: 25),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nationality = c.String(maxLength: 20),
                        Address = c.String(maxLength: 100),
                        Gender = c.Int(nullable: false),
                        CareerEmail = c.String(maxLength: 100),
                        ResumeURL = c.String(),
                        TwitterURL = c.String(),
                        LinkedIn = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.UserID)
                .Index(t => t.UserID);
            
            AddColumn("dbo.Companies", "LicenseNumber", c => c.String());
            AddColumn("dbo.Companies", "AdditionalInformation", c => c.String());
            AddColumn("dbo.Companies", "WebsiteUrl", c => c.String());
            AddColumn("dbo.Companies", "TwitterUrl", c => c.String());
            AddColumn("dbo.Jobs", "JobCategoryId", c => c.Long(nullable: false));
            AddColumn("dbo.EducationBackgrounds", "JobSeekerID", c => c.Long());
            AddColumn("dbo.Languages", "JobSeeker_ID", c => c.Long());
            AddColumn("dbo.WorkExperiences", "JobSeekerID", c => c.Long());
            AddColumn("dbo.Users", "UserType", c => c.Int(nullable: false));
            CreateIndex("dbo.Jobs", "JobCategoryId");
            CreateIndex("dbo.EducationBackgrounds", "JobSeekerID");
            CreateIndex("dbo.Languages", "JobSeeker_ID");
            CreateIndex("dbo.JobApplications", "User_Id");
            CreateIndex("dbo.WorkExperiences", "JobSeekerID");
            AddForeignKey("dbo.Jobs", "JobCategoryId", "dbo.JobCategories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EducationBackgrounds", "JobSeekerID", "dbo.JobSeekers", "ID");
            AddForeignKey("dbo.Languages", "JobSeeker_ID", "dbo.JobSeekers", "ID");
            AddForeignKey("dbo.WorkExperiences", "JobSeekerID", "dbo.JobSeekers", "ID");
            DropColumn("dbo.EducationBackgrounds", "Resume_ID");
            DropColumn("dbo.WorkExperiences", "ResumeId");
            DropColumn("dbo.Users", "IsCompanyUser");
            DropColumn("dbo.Users", "Resume_ID");
            DropTable("dbo.Resumes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        FullName = c.String(maxLength: 100),
                        AdditionalInformation = c.String(),
                        ProfileImageUri = c.String(),
                        CareerObjective = c.String(),
                        SkillsAndQualifications = c.String(),
                        FirstName = c.String(maxLength: 25),
                        SecondName = c.String(maxLength: 25),
                        DateOfBirth = c.DateTime(nullable: false),
                        Nationality = c.String(maxLength: 20),
                        Address = c.String(maxLength: 100),
                        Gender = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Users", "Resume_ID", c => c.Long());
            AddColumn("dbo.Users", "IsCompanyUser", c => c.Boolean(nullable: false));
            AddColumn("dbo.WorkExperiences", "ResumeId", c => c.Long(nullable: false));
            AddColumn("dbo.EducationBackgrounds", "Resume_ID", c => c.Long());
            DropForeignKey("dbo.WorkExperiences", "JobSeekerID", "dbo.JobSeekers");
            DropForeignKey("dbo.JobSeekers", "UserID", "dbo.Users");
            DropForeignKey("dbo.Languages", "JobSeeker_ID", "dbo.JobSeekers");
            DropForeignKey("dbo.EducationBackgrounds", "JobSeekerID", "dbo.JobSeekers");
            DropForeignKey("dbo.Jobs", "JobCategoryId", "dbo.JobCategories");
            DropIndex("dbo.WorkExperiences", new[] { "JobSeekerID" });
            DropIndex("dbo.JobApplications", new[] { "User_Id" });
            DropIndex("dbo.Languages", new[] { "JobSeeker_ID" });
            DropIndex("dbo.JobSeekers", new[] { "UserID" });
            DropIndex("dbo.EducationBackgrounds", new[] { "JobSeekerID" });
            DropIndex("dbo.Jobs", new[] { "JobCategoryId" });
            DropColumn("dbo.Users", "UserType");
            DropColumn("dbo.WorkExperiences", "JobSeekerID");
            DropColumn("dbo.Languages", "JobSeeker_ID");
            DropColumn("dbo.EducationBackgrounds", "JobSeekerID");
            DropColumn("dbo.Jobs", "JobCategoryId");
            DropColumn("dbo.Companies", "TwitterUrl");
            DropColumn("dbo.Companies", "WebsiteUrl");
            DropColumn("dbo.Companies", "AdditionalInformation");
            DropColumn("dbo.Companies", "LicenseNumber");
            DropTable("dbo.JobSeekers");
            DropTable("dbo.JobCategories");
            CreateIndex("dbo.JobApplications", "user_Id");
            CreateIndex("dbo.Users", "Resume_ID");
            CreateIndex("dbo.WorkExperiences", "ResumeId");
            CreateIndex("dbo.Languages", "ResumeId");
            CreateIndex("dbo.EducationBackgrounds", "Resume_ID");
            AddForeignKey("dbo.Users", "Resume_ID", "dbo.Resumes", "ID");
            AddForeignKey("dbo.WorkExperiences", "ResumeId", "dbo.Resumes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Languages", "ResumeId", "dbo.Resumes", "ID", cascadeDelete: true);
            AddForeignKey("dbo.EducationBackgrounds", "Resume_ID", "dbo.Resumes", "ID");
        }
    }
}
