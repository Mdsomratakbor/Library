﻿// <auto-generated />
using System;
using Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library.Data.Migrations
{
    [DbContext(typeof(LibraryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Library.Data.Models.BranchHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("CloseTime")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("OpenTime")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("BranchHours");
                });

            modelBuilder.Entity("Library.Data.Models.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("LibraryAssetId")
                        .HasColumnType("int");

                    b.Property<int?>("LibraryCardId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Since")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Until")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LibraryAssetId");

                    b.HasIndex("LibraryCardId");

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("Library.Data.Models.CheckoutHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime?>("CheckedIn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CheckedOut")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LibraryAssetId")
                        .HasColumnType("int");

                    b.Property<int?>("LibraryCardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibraryAssetId");

                    b.HasIndex("LibraryCardId");

                    b.ToTable("CheckoutHistories");
                });

            modelBuilder.Entity("Library.Data.Models.Hold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("HoldPlaced")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LibraryAssetId")
                        .HasColumnType("int");

                    b.Property<int?>("LibraryCardId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LibraryAssetId");

                    b.HasIndex("LibraryCardId");

                    b.ToTable("Holds");
                });

            modelBuilder.Entity("Library.Data.Models.LibraryAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfCopies")
                        .HasColumnType("int");

                    b.Property<int?>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("StatusId");

                    b.ToTable("LibraryAssets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("LibraryAsset");
                });

            modelBuilder.Entity("Library.Data.Models.LibraryBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LibraryBranches");
                });

            modelBuilder.Entity("Library.Data.Models.LibraryCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Fees")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("LibraryCards");
                });

            modelBuilder.Entity("Library.Data.Models.Patron", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HomeLibraryBranchId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("LibraryCardId")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HomeLibraryBranchId");

                    b.HasIndex("LibraryCardId");

                    b.ToTable("Patrons");
                });

            modelBuilder.Entity("Library.Data.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("Library.Data.Models.Book", b =>
                {
                    b.HasBaseType("Library.Data.Models.LibraryAsset");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DeweyIndex")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("Library.Data.Models.Video", b =>
                {
                    b.HasBaseType("Library.Data.Models.LibraryAsset");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Video");
                });

            modelBuilder.Entity("Library.Data.Models.BranchHours", b =>
                {
                    b.HasOne("Library.Data.Models.LibraryBranch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("Library.Data.Models.Checkout", b =>
                {
                    b.HasOne("Library.Data.Models.LibraryAsset", "LibraryAsset")
                        .WithMany()
                        .HasForeignKey("LibraryAssetId");

                    b.HasOne("Library.Data.Models.LibraryCard", "LibraryCard")
                        .WithMany("Checkouts")
                        .HasForeignKey("LibraryCardId");

                    b.Navigation("LibraryAsset");

                    b.Navigation("LibraryCard");
                });

            modelBuilder.Entity("Library.Data.Models.CheckoutHistory", b =>
                {
                    b.HasOne("Library.Data.Models.LibraryAsset", "LibraryAsset")
                        .WithMany()
                        .HasForeignKey("LibraryAssetId");

                    b.HasOne("Library.Data.Models.LibraryCard", "LibraryCard")
                        .WithMany()
                        .HasForeignKey("LibraryCardId");

                    b.Navigation("LibraryAsset");

                    b.Navigation("LibraryCard");
                });

            modelBuilder.Entity("Library.Data.Models.Hold", b =>
                {
                    b.HasOne("Library.Data.Models.LibraryAsset", "LibraryAsset")
                        .WithMany()
                        .HasForeignKey("LibraryAssetId");

                    b.HasOne("Library.Data.Models.LibraryCard", "LibraryCard")
                        .WithMany()
                        .HasForeignKey("LibraryCardId");

                    b.Navigation("LibraryAsset");

                    b.Navigation("LibraryCard");
                });

            modelBuilder.Entity("Library.Data.Models.LibraryAsset", b =>
                {
                    b.HasOne("Library.Data.Models.LibraryBranch", "Location")
                        .WithMany("LibraryAssets")
                        .HasForeignKey("LocationId");

                    b.HasOne("Library.Data.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.Navigation("Location");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Library.Data.Models.Patron", b =>
                {
                    b.HasOne("Library.Data.Models.LibraryBranch", "HomeLibraryBranch")
                        .WithMany("Patrons")
                        .HasForeignKey("HomeLibraryBranchId");

                    b.HasOne("Library.Data.Models.LibraryCard", "LibraryCard")
                        .WithMany()
                        .HasForeignKey("LibraryCardId");

                    b.Navigation("HomeLibraryBranch");

                    b.Navigation("LibraryCard");
                });

            modelBuilder.Entity("Library.Data.Models.LibraryBranch", b =>
                {
                    b.Navigation("LibraryAssets");

                    b.Navigation("Patrons");
                });

            modelBuilder.Entity("Library.Data.Models.LibraryCard", b =>
                {
                    b.Navigation("Checkouts");
                });
#pragma warning restore 612, 618
        }
    }
}
