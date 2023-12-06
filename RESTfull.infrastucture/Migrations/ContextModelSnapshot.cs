﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RESTfull.Infrastructure;

#nullable disable

namespace RESTfull.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    partial class ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RESRTfull.Domain.Address", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AddressPermanentRegistration")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressTemporaryRegistration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IndividualID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IndividualID")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("RESRTfull.Domain.DocForeignPassport", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocumentCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("Date");

                    b.Property<string>("DocumentSeries")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IndividualID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IndividualID")
                        .IsUnique();

                    b.ToTable("ForeignPassports");
                });

            modelBuilder.Entity("RESRTfull.Domain.DocInternationalPassport", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DocumentDateOfIssue")
                        .HasColumnType("Date");

                    b.Property<DateTime>("DocumentExpirationDate")
                        .HasColumnType("Date");

                    b.Property<string>("DocumentIssuer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentSeries")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IndividualID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IndividualID")
                        .IsUnique();

                    b.ToTable("InternationalPassports");
                });

            modelBuilder.Entity("RESRTfull.Domain.DocRussianPassport", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DocumentDate")
                        .HasColumnType("Date");

                    b.Property<string>("DocumentIssuer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentIssuerCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentSeries")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IndividualID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IndividualID")
                        .IsUnique();

                    b.ToTable("RussianPassports");
                });

            modelBuilder.Entity("RESRTfull.Domain.Document", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DocumentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IndividualID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IndividualID");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("RESRTfull.Domain.Education", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("Date");

                    b.Property<Guid>("IndividualID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IndividualID");

                    b.ToTable("Educations");
                });

            modelBuilder.Entity("RESRTfull.Domain.Individual", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.ToTable("Individuals");
                });

            modelBuilder.Entity("RESRTfull.Domain.Info", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IndividualID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IndividualID")
                        .IsUnique();

                    b.ToTable("Infos");
                });

            modelBuilder.Entity("RESRTfull.Domain.Job", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IndividualID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Organization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("IndividualID");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("RESRTfull.Domain.Address", b =>
                {
                    b.HasOne("RESRTfull.Domain.Individual", "Individual")
                        .WithOne("PersonAddress")
                        .HasForeignKey("RESRTfull.Domain.Address", "IndividualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("RESRTfull.Domain.DocForeignPassport", b =>
                {
                    b.HasOne("RESRTfull.Domain.Individual", "Individual")
                        .WithOne("ForeignPassport")
                        .HasForeignKey("RESRTfull.Domain.DocForeignPassport", "IndividualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("RESRTfull.Domain.DocInternationalPassport", b =>
                {
                    b.HasOne("RESRTfull.Domain.Individual", "Individual")
                        .WithOne("InternationalPassport")
                        .HasForeignKey("RESRTfull.Domain.DocInternationalPassport", "IndividualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("RESRTfull.Domain.DocRussianPassport", b =>
                {
                    b.HasOne("RESRTfull.Domain.Individual", "Individual")
                        .WithOne("RussianPassport")
                        .HasForeignKey("RESRTfull.Domain.DocRussianPassport", "IndividualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("RESRTfull.Domain.Document", b =>
                {
                    b.HasOne("RESRTfull.Domain.Individual", "Individual")
                        .WithMany("Documents")
                        .HasForeignKey("IndividualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("RESRTfull.Domain.Education", b =>
                {
                    b.HasOne("RESRTfull.Domain.Individual", "Individual")
                        .WithMany("Educations")
                        .HasForeignKey("IndividualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("RESRTfull.Domain.Info", b =>
                {
                    b.HasOne("RESRTfull.Domain.Individual", "Individual")
                        .WithOne("Information")
                        .HasForeignKey("RESRTfull.Domain.Info", "IndividualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("RESRTfull.Domain.Job", b =>
                {
                    b.HasOne("RESRTfull.Domain.Individual", "Individual")
                        .WithMany("Jobs")
                        .HasForeignKey("IndividualID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Individual");
                });

            modelBuilder.Entity("RESRTfull.Domain.Individual", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Educations");

                    b.Navigation("ForeignPassport");

                    b.Navigation("Information")
                        .IsRequired();

                    b.Navigation("InternationalPassport");

                    b.Navigation("Jobs");

                    b.Navigation("PersonAddress")
                        .IsRequired();

                    b.Navigation("RussianPassport");
                });
#pragma warning restore 612, 618
        }
    }
}
