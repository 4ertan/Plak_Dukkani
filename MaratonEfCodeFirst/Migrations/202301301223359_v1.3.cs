namespace MaratonEfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v13 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Albums",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Sanatci = c.String(),
                        CikisT = c.DateTime(nullable: false),
                        Fiyat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IndirimOrani = c.Int(nullable: false),
                        SatisDurum = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AlbumID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Albums");
        }
    }
}
