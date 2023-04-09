namespace MaratonEfCodeFirst.Migrations
{
    using MaratonEfCodeFirst.Context;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MaratonEfCodeFirst.Context.Model1>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MaratonEfCodeFirst.Context.Model1";
        }

        protected override void Seed(MaratonEfCodeFirst.Context.Model1 context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            Model1 db = new Model1();
            List<Album> albumList = new List<Album>
            {
                new Album{Title="Sezen 88",Sanatci="Sezen aksu",CikisT=DateTime.Now,SatisDurum=true,Fiyat=199},
                 new Album{Title="Murat 99",Sanatci="Murat Boz",CikisT=DateTime.Now,SatisDurum=true,Fiyat=120},
                  new Album{Title="Bergenden",Sanatci="Bergen"
                  ,CikisT=DateTime.Now,SatisDurum=true,Fiyat=250},
                 new Album{Title="Baba",Sanatci="Muslum"
                 ,CikisT=DateTime.Now,SatisDurum=true,Fiyat=300}
            };
            foreach (var item in albumList)
            {
                db.Albums.AddOrUpdate(item);
            }
        }
    }
}
