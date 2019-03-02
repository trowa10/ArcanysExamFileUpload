namespace DragAndDrapMVC.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using DragAndDrapMVC.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<DragAndDrapMVC.Context.ApplicationContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DragAndDrapMVC.Context.ApplicationContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //var files = new List<File>() {
            //   new File{ Name="test1",Extension = "jpg", Size = 2097152, Content =null },
            //    new File{ Name="test2",Extension = "jpg", Size = 2097152, Content =null },
            //};

            //files.ForEach(e => context.Files.AddOrUpdate(p => p.Id, e));
            //context.SaveChanges();

            //truncate

            context.Database.ExecuteSqlCommand("TRUNCATE TABLE [Files]");
        }
    }


}
