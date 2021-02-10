using NinjaDomainClasses;
using System.Collections.Generic;
using System.Data.Entity;

namespace NinjaDomain.Classes
{
    public class NinjaContext:DbContext
    {
        public DbSet<Ninja> Ninjas { get; set; }
        public DbSet<Clan> Clans { get; set; }
        public DbSet<NinjaEquipment> Equipment { get; set; }
    }
}
