namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedisCompletedBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "balance", c => c.Double(nullable: false));
            AddColumn("dbo.Employees", "isCompleted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "isCompleted");
            DropColumn("dbo.Employees", "balance");
        }
    }
}
