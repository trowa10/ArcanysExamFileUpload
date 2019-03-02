using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DragAndDrapMVC.Models;
namespace DragAndDrapMVC.Context
{
    public class ApplicationContext : DbContext
    {

        public ApplicationContext() : base("ApplicationContext")
        {

        }
        public DbSet<File> Files { get; set; }
    }
}