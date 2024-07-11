namespace SharingThesis.Management.Metier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class error : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Td_Erreur",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateErreur = c.DateTime(nullable: false, precision: 0),
                        DescriptionErreur = c.String(nullable: false, maxLength: 3000, storeType: "nvarchar"),
                        TitreErreur = c.String(nullable: false, maxLength: 3000, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Td_Erreur");
        }
    }
}
