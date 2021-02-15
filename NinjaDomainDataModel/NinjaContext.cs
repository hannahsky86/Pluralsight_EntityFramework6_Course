using NinjaDomainClasses;
using NinjaDomainClasses.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace NinjaDomain.Classes
{
    public class NinjaContext:DbContext, IModificationHistory
    {
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<NinjaEquipment> Equipment { get; set; }
        public DateTime DateModified { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsDirty { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Types().Configure(c => c.Ignore("IsDirty"));
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory && (e.State == EntityState.Added ||
                   e.State == EntityState.Modified))
                .Select(e => e.Entity as IModificationHistory)
                )
            {
                _ = history.DateModified == DateTime.Now;
                if (history.DateCreated == DateTime.MinValue)
                {
                    history.DateCreated = DateTime.Now;
                }
            }
            int result = base.SaveChanges();
            foreach (var history in this.ChangeTracker.Entries()
                .Where(e => e.Entity is IModificationHistory)
                .Select(e => e.Entity as IModificationHistory)
                )
            {
                history.IsDirty = false;
            }
            return result;
        }
    }
}
