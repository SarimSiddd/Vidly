namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNameInMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'Pay as You Go' where DurationInMonths =0");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'Monthly' where DurationInMonths =1");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'Quarterly' where DurationInMonths =3");
            Sql("UPDATE MEMBERSHIPTYPES SET NAME = 'Yearly' where DurationInMonths =12");
        }
        
        public override void Down()
        {
        }
    }
}
