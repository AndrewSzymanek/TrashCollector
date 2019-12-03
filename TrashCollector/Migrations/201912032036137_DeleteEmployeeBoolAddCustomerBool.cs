namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteEmployeeBoolAddCustomerBool : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "isCompleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Employees", "isCompleted");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "isCompleted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "isCompleted");
        }
    }
}
