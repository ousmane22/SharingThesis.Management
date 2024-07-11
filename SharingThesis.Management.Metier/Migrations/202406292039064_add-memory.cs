namespace SharingThesis.Management.Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmemory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Memoires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Memoires");
        }
    }
}
