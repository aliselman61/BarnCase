namespace BarnCase.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Animals",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Username = c.String(),
                        Name = c.String(),
                        Type = c.String(),
                        Age = c.Int(),
                        Gender = c.String(),
                        Price = c.Decimal(precision: 18, scale: 2),
                        DeathCause = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Hash",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Email = c.String(),
                        PasswordHash = c.Binary(),
                        PasswordSalt = c.Binary(),
                        Iterations = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.UserMoney",
                c => new
                    {
                        Username = c.String(nullable: false, maxLength: 128),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Username);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserMoney");
            DropTable("dbo.Hash");
            DropTable("dbo.Animals");
        }
    }
}
