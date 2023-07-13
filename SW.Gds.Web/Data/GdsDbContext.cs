using Microsoft.EntityFrameworkCore;
using SW.EfCoreExtensions;
using SW.Gds.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SW.Gds
{
    public class GdsDbContext : DbContext
    {

        public const string ConnectionString = "GdsDb";
        public const string Schema = "gds";

        public GdsDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasDefaultSchema(Schema);

            modelBuilder.Entity<Country>(b =>
            {
                b.Property(p => p.Id).IsCode(2, true, true);
                b.Property(p => p.IsoCode3).IsCode(3, true, true);
                b.Property(p => p.CurrencyCode).IsCode(3, true, true);

                b.Property(p => p.Name).HasMaxLength(1000).IsRequired();
                b.Property(p => p.Capital).HasMaxLength(1000);
                b.Property(p => p.CurrencyName).HasMaxLength(1000);
                b.Property(p => p.Languages).HasMaxLength(1000);
                b.Property(p => p.PostCodeFormat).HasMaxLength(1000);
                b.Property(p => p.PostCodeRegex).HasMaxLength(1000);
                b.Property(p => p.Tld).HasMaxLength(1000);
                b.Property(p => p.Phone).HasMaxLength(1000);


                b.HasIndex(p => p.CurrencyCode);
                b.HasIndex(p => p.IsoCode3);
                b.HasIndex(p => p.IsoNumber);

            });

            //modelBuilder.Entity<Currency>(b =>
            //{
            //    b.Property(p => p.Id).IsCode(3, true, true);

            //});

            modelBuilder.Entity<PhoneNumberingPlan>(b =>
            {
                b.Property(p => p.Country).IsCode(2, true, true);
                b.Property(p => p.Type).HasConversion<byte>();

            });
        }
    }
}
