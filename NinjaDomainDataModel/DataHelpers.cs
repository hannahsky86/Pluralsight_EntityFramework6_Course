using NinjaDomain.Classes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NinjaDomainDataModel
{
    public class DataHelpers
    {
        public static void NewDbWithSeed()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<NinjaContext>());
            using(var context = new NinjaContext())
            {
                if (context.Ninjas.Any())
                {
                    return;
                }
                var vtClan = context.Clans.Add(new NinjaDomainClasses.Clan { ClanName = "Vermont Clan" });
                var turtleClan = context.Clans.Add(new NinjaDomainClasses.Clan { ClanName = "Turtles" });
                var amClan = context.Clans.Add(new NinjaDomainClasses.Clan { ClanName = "American Ninja Warriors" });
            }
        }
    }
}
