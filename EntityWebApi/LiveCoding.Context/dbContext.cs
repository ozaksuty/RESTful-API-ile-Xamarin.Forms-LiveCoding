using LiveCoding.Model;
using System.Data.Entity;

namespace LiveCoding.Context
{
    public partial class dbContext : DbContext
    {
        public dbContext()
            : base("name=XamarinTRConnection")
        {
            Database.SetInitializer<DbContext>(new CreateDatabaseIfNotExists<DbContext>());
        }

        public virtual DbSet<Student> Student { get; set; }
        public virtual DbSet<Department> Department { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .HasMany(e => e.Student)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.DepartmentID);
        }
    }
}