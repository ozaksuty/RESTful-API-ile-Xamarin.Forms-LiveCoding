namespace LiveCoding.Context.Migrations
{
    using Model;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(dbContext context)
        {
            List<Department> departmentList = new List<Department>()
            {
                new Department() { DepartmanName = "Computer Technologies" },
                new Department() { DepartmanName = "Computer Engineering" },
                new Department() { DepartmanName = "Software Engineering" }
            };

            context.Department.AddOrUpdate(departmentList.ToArray());
        }
    }
}
