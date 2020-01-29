namespace ITI.MVC.LinkedIn.DbLayer
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}