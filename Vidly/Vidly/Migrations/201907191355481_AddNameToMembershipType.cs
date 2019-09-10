namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 255));
            Sql("Update MembershipTypes set Name = 'Pay As You Go' where SignUpFee = 0");
            Sql("Update MembershipTypes set Name = 'Monthly' where SignUpFee = 30");
            Sql("Update MembershipTypes set Name = 'Quaterly' where SignUpFee = 90");
            Sql("Update MembershipTypes set Name = 'Annually' where SignUpFee = 300");

        }

        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
