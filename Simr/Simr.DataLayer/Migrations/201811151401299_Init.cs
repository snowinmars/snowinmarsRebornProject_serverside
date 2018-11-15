namespace Simr.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DbAuthors",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsSynchronized = c.Boolean(nullable: false),
                        FamilyName = c.String(),
                        FullMiddleName = c.String(),
                        GivenName = c.String(),
                        PseudonymFamilyName = c.String(),
                        PseudonymFullMiddleName = c.String(),
                        PseudonymGivenName = c.String(),
                        Aka = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbBooks",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsSynchronized = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        AdditionalInfo = c.String(),
                        Bookshelf = c.String(),
                        FlibustaUrl = c.String(),
                        LibRusEcUrl = c.String(),
                        LiveLibUrl = c.String(),
                        Owner = c.String(),
                        PageCount = c.Int(nullable: false),
                        Title = c.String(),
                        Year = c.Int(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DbUsers",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IsSynchronized = c.Boolean(nullable: false),
                        Email = c.String(),
                        Language = c.Int(nullable: false),
                        Roles = c.Int(nullable: false),
                        Username = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DbUsers");
            DropTable("dbo.DbBooks");
            DropTable("dbo.DbAuthors");
        }
    }
}
