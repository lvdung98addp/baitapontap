namespace BaiTapOnTap.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class abcd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SinhViens", "GioiTinh", c => c.String());
            AddColumn("dbo.SinhViens", "ChuyenNganh", c => c.String());
            AddColumn("dbo.SinhViens", "Diem1", c => c.Single(nullable: false));
            AddColumn("dbo.SinhViens", "Diem2", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SinhViens", "Diem2");
            DropColumn("dbo.SinhViens", "Diem1");
            DropColumn("dbo.SinhViens", "ChuyenNganh");
            DropColumn("dbo.SinhViens", "GioiTinh");
        }
    }
}
