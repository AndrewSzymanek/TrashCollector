namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletedemployeebalance : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Employees", "balance");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "balance", c => c.Double(nullable: false));
        }
    }
}
