﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SW.Gds;

namespace SW.Gds.Migrations
{
    [DbContext(typeof(GdsDbContext))]
    partial class GdsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("gds")
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("SW.Gds.Domain.Country", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character(2)")
                        .HasColumnName("id")
                        .IsFixedLength(true);

                    b.Property<string>("Capital")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("capital");

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("character(3)")
                        .HasColumnName("currency_code")
                        .IsFixedLength(true);

                    b.Property<string>("CurrencyName")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("currency_name");

                    b.Property<string>("IsoCode3")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("character(3)")
                        .HasColumnName("iso_code3")
                        .IsFixedLength(true);

                    b.Property<short>("IsoNumber")
                        .HasColumnType("smallint")
                        .HasColumnName("iso_number");

                    b.Property<string>("Languages")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("languages");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("name");

                    b.Property<string>("Phone")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("phone");

                    b.Property<string>("PostCodeFormat")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("post_code_format");

                    b.Property<string>("PostCodeRegex")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("post_code_regex");

                    b.Property<string>("Tld")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)")
                        .HasColumnName("tld");

                    b.HasKey("Id")
                        .HasName("pk_country");

                    b.HasIndex("CurrencyCode")
                        .HasDatabaseName("ix_country_currency_code");

                    b.HasIndex("IsoCode3")
                        .HasDatabaseName("ix_country_iso_code3");

                    b.HasIndex("IsoNumber")
                        .HasDatabaseName("ix_country_iso_number");

                    b.ToTable("country", "gds");
                });

            modelBuilder.Entity("SW.Gds.Domain.PhoneNumberingPlan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<byte>("AreaCodeLength")
                        .HasColumnType("smallint")
                        .HasColumnName("area_code_length");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(2)
                        .IsUnicode(false)
                        .HasColumnType("character(2)")
                        .HasColumnName("country")
                        .IsFixedLength(true);

                    b.Property<byte>("MaxLength")
                        .HasColumnType("smallint")
                        .HasColumnName("max_length");

                    b.Property<byte>("MinLength")
                        .HasColumnType("smallint")
                        .HasColumnName("min_length");

                    b.Property<byte>("Type")
                        .HasColumnType("smallint")
                        .HasColumnName("type");

                    b.HasKey("Id")
                        .HasName("pk_phone_numbering_plan");

                    b.ToTable("phone_numbering_plan", "gds");
                });
#pragma warning restore 612, 618
        }
    }
}
