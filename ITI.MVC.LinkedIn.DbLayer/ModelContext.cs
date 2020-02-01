namespace ITI.MVC.LinkedIn.DbLayer
{
    using ITI.MVC.LinkedIn.DbLayer.Entities;
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

        public virtual DbSet<Patent> Patents { get; set; }

        public virtual DbSet<Awards> Awards { get; set; }

        public virtual DbSet<TestScore> TestScores { get; set; }

        public virtual DbSet<Course> Courses { get; set; }

        public virtual DbSet<Post> Posts { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }
    }
}