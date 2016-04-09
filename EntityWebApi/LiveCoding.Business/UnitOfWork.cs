using LiveCoding.Context;
using LiveCoding.Model;
using System;
using System.Data.Entity;
using System.Linq;

namespace LiveCoding.Business
{
    public class UnitOfWork : IDisposable
    {
        private static readonly dbContext context = new dbContext();

        private GenericRepository<Student> _studentRepository;
        private GenericRepository<Department> _departmentRepository;

        public GenericRepository<Student> StudentRepository
        {
            get
            {
                if (this._studentRepository == null)
                {
                    this._studentRepository = new GenericRepository<Student>(context);
                }
                return _studentRepository;
            }
        }

        public GenericRepository<Department> DepartmentRepository
        {
            get
            {
                if (this._departmentRepository == null)
                {
                    this._departmentRepository = new GenericRepository<Department>(context);
                }
                return _departmentRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void UndoAll()
        {
            context.ChangeTracker.DetectChanges();

            var entries = context.ChangeTracker.Entries().Where(e => e.State != EntityState.Unchanged).ToList();

            foreach (var dbEntityEntry in entries)
            {
                var entity = dbEntityEntry.Entity;

                if (entity == null) continue;

                if (dbEntityEntry.State == EntityState.Added)
                {
                    var set = context.Set(entity.GetType());
                    set.Remove(entity);
                }
                else if (dbEntityEntry.State == EntityState.Modified)
                {
                    dbEntityEntry.Reload();
                }
                else if (dbEntityEntry.State == EntityState.Deleted)
                    dbEntityEntry.State = EntityState.Modified;
            }
        }
    }
}
