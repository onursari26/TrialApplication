using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Application.Data.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Seeding
{
    public class StoreSeed : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            var store = new Store
            {
                Id = 37814,
                Name = "Stock Mount",
                Description = "Stock Mount",
            };

            builder.HasData(store);
            //context.Store.Add(store);

            //context.Database.OpenConnection();
            //try
            //{
            //    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Store ON;");
            //    context.SaveChanges();
            //    context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.Store OFF;");
            //}
            //finally
            //{
            //    context.Database.CloseConnection();
            //}
        }
    }
}
