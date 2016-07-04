namespace SimpleASPmvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "GroupName", c => c.String());
            DropColumn("dbo.Groups", "Group_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "Group_Name", c => c.String());
            DropColumn("dbo.Groups", "GroupName");
        }
    }
}
