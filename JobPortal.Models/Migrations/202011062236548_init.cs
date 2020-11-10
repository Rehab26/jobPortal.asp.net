namespace JobPortal.Models.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Companies",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        UserId = c.String(),
                        CompanyEmail = c.String(maxLength: 100),
                        Name = c.String(maxLength: 80),
                        Location = c.String(maxLength: 255),
                        Description = c.String(),
                        ProfileImageUri = c.String(),
                        ContactNumberOne = c.String(),
                        ContactNumberTwo = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        NumberOfApplicants = c.Int(nullable: false),
                        Title = c.String(),
                        Location = c.String(),
                        Description = c.String(),
                        MinimumSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MaximumSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RequiredSkills = c.String(),
                        Responsibilities = c.String(),
                        YearsOfExperience = c.Long(nullable: false),
                        Specialization = c.String(),
                        DatePosted = c.DateTime(nullable: false),
                        ApplicationDeadline = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        ExperienceLevel = c.Int(nullable: false),
                        JobStatus = c.Int(nullable: false),
                        CompanyId = c.Long(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Companies", t => t.CompanyId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.CompanyId)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.EducationBackgrounds",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        InstitutionName = c.String(maxLength: 50),
                        DegreeAwarded = c.String(),
                        Description = c.String(maxLength: 255),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        Resume_ID = c.Long(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resumes", t => t.Resume_ID)
                .Index(t => t.Resume_ID);
            
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
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Int(nullable: false),
                        ResumeId = c.Long(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resumes", t => t.ResumeId, cascadeDelete: true)
                .Index(t => t.ResumeId);
            
            CreateTable(
                "dbo.WorkExperiences",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        CompanyName = c.String(maxLength: 50),
                        Designation = c.String(maxLength: 50),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        JobDescription = c.String(maxLength: 255),
                        ResumeId = c.Long(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Resumes", t => t.ResumeId, cascadeDelete: true)
                .Index(t => t.ResumeId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IsCompanyUser = c.Boolean(nullable: false),
                        checkId = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Resume_ID = c.Long(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Resumes", t => t.Resume_ID)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Resume_ID);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        applicationStatus = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        DateModified = c.DateTime(nullable: false),
                        job_ID = c.Long(),
                        user_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Jobs", t => t.job_ID)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.job_ID)
                .Index(t => t.user_Id);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "Resume_ID", "dbo.Resumes");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.JobApplications", "user_Id", "dbo.Users");
            DropForeignKey("dbo.JobApplications", "job_ID", "dbo.Jobs");
            DropForeignKey("dbo.Jobs", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.WorkExperiences", "ResumeId", "dbo.Resumes");
            DropForeignKey("dbo.Languages", "ResumeId", "dbo.Resumes");
            DropForeignKey("dbo.EducationBackgrounds", "Resume_ID", "dbo.Resumes");
            DropForeignKey("dbo.Jobs", "CompanyId", "dbo.Companies");
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.JobApplications", new[] { "user_Id" });
            DropIndex("dbo.JobApplications", new[] { "job_ID" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "Resume_ID" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.WorkExperiences", new[] { "ResumeId" });
            DropIndex("dbo.Languages", new[] { "ResumeId" });
            DropIndex("dbo.EducationBackgrounds", new[] { "Resume_ID" });
            DropIndex("dbo.Jobs", new[] { "User_Id" });
            DropIndex("dbo.Jobs", new[] { "CompanyId" });
            DropTable("dbo.UserLogins");
            DropTable("dbo.JobApplications");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Roles");
            DropTable("dbo.WorkExperiences");
            DropTable("dbo.Languages");
            DropTable("dbo.Resumes");
            DropTable("dbo.EducationBackgrounds");
            DropTable("dbo.Jobs");
            DropTable("dbo.Companies");
        }
    }
}
