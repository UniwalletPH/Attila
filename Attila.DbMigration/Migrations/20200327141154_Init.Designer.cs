﻿// <auto-generated />
using System;
using Attila.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Attila.DbMigration.Migrations
{
    [DbContext(typeof(AttilaDbContext))]
    [Migration("20200327141154_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Attila.Domain.Entities.ClientDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("ClientDetails");
                });

            modelBuilder.Entity("Attila.Domain.Entities.DeliveryDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DeliveryPrice")
                        .HasColumnType("DECIMAL(20,8)");

                    b.Property<byte[]>("ReceiptImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupplierDetailsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SupplierDetailsID");

                    b.ToTable("DeliveryDetails");
                });

            modelBuilder.Entity("Attila.Domain.Entities.EquipmentDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("EquipmentType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RentalFee")
                        .HasColumnType("DECIMAL(20,8)");

                    b.Property<byte>("UnitType")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.ToTable("EquipmentDetails");
                });

            modelBuilder.Entity("Attila.Domain.Entities.EquipmentInventory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EncodingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentRestockID")
                        .HasColumnType("int");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("DECIMAL(20,8)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EquipmentDetailsID");

                    b.HasIndex("EquipmentRestockID");

                    b.HasIndex("UserID");

                    b.ToTable("EquipmentInventories");
                });

            modelBuilder.Entity("Attila.Domain.Entities.EquipmentRestockRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeRequest")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EquipmentDetailsID");

                    b.HasIndex("UserID");

                    b.ToTable("EquipmentRestockRequests");
                });

            modelBuilder.Entity("Attila.Domain.Entities.EventAdditionalDurationRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("EventDetailsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EventDetailsID");

                    b.ToTable("EventAdditionalDurationRequests");
                });

            modelBuilder.Entity("Attila.Domain.Entities.EventAdditionalEquipmentRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EquipmentDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("EventDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.HasIndex("EquipmentDetailsID");

                    b.HasIndex("EventDetailsID");

                    b.ToTable("EventAdditionalEquipmentRequests");
                });

            modelBuilder.Entity("Attila.Domain.Entities.EventDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("EntryTime")
                        .HasColumnType("time");

                    b.Property<int>("EventClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("EventStatus")
                        .HasColumnType("tinyint");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LocationType")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfGuests")
                        .HasColumnType("int");

                    b.Property<int>("PackageDetailsID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("ProgramStart")
                        .HasColumnType("time");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("ServingTime")
                        .HasColumnType("time");

                    b.Property<byte>("ServingType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Theme")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<byte>("VenueType")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.HasIndex("EventClientID");

                    b.HasIndex("PackageDetailsID");

                    b.HasIndex("UserID");

                    b.ToTable("EventDetails");
                });

            modelBuilder.Entity("Attila.Domain.Entities.EventMenus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("MenuID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EventDetailsID");

                    b.HasIndex("MenuID");

                    b.ToTable("EventMenus");
                });

            modelBuilder.Entity("Attila.Domain.Entities.FoodDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("FoodType")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Unit")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.ToTable("FoodDetails");
                });

            modelBuilder.Entity("Attila.Domain.Entities.FoodInventory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EncodingDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("FoodDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("FoodRestockID")
                        .HasColumnType("int");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("DECIMAL(20,8)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FoodDetailsID");

                    b.HasIndex("FoodRestockID");

                    b.HasIndex("UserID");

                    b.ToTable("FoodInventories");
                });

            modelBuilder.Entity("Attila.Domain.Entities.FoodRestockRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeRequest")
                        .HasColumnType("datetime2");

                    b.Property<int>("FoodDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FoodDetailsID");

                    b.HasIndex("UserID");

                    b.ToTable("FoodRestockRequests");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MenuCategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MenuCategoryID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("Attila.Domain.Entities.MenuCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("MenuCategories");
                });

            modelBuilder.Entity("Attila.Domain.Entities.PackageEquipments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EquipmentDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("PackageMenuDetailsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EquipmentDetailsID");

                    b.HasIndex("PackageMenuDetailsID");

                    b.ToTable("PackageEquipments");
                });

            modelBuilder.Entity("Attila.Domain.Entities.PackageMenuDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RatePerHead")
                        .HasColumnType("DECIMAL(20,8)");

                    b.HasKey("ID");

                    b.ToTable("PackageMenuDetails");
                });

            modelBuilder.Entity("Attila.Domain.Entities.PackageMenus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MenuID")
                        .HasColumnType("int");

                    b.Property<int>("PackageMenuDetailsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MenuID");

                    b.HasIndex("PackageMenuDetailsID");

                    b.ToTable("PackageMenus");
                });

            modelBuilder.Entity("Attila.Domain.Entities.PaymentStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("DECIMAL(20,8)");

                    b.Property<DateTime>("DateOfPayment")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventDetailsID")
                        .HasColumnType("int");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("EventDetailsID");

                    b.ToTable("PaymentStatus");
                });

            modelBuilder.Entity("Attila.Domain.Entities.SupplierDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPersonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("SupplierDetails");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.EventEquipments", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EquipmentDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("EventDetailsID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("EquipmentDetailsID");

                    b.HasIndex("EventDetailsID");

                    b.ToTable("EventEquipments");
                });

            modelBuilder.Entity("Attila.Domain.Entities.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Role")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Attila.Domain.Entities.UserLogins", b =>
                {
                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<byte[]>("Password")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("Salt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Attila.Domain.Entities.DeliveryDetails", b =>
                {
                    b.HasOne("Attila.Domain.Entities.SupplierDetails", "SupplierDetails")
                        .WithMany()
                        .HasForeignKey("SupplierDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.EquipmentInventory", b =>
                {
                    b.HasOne("Attila.Domain.Entities.EquipmentDetails", "EquipmentDetails")
                        .WithMany()
                        .HasForeignKey("EquipmentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.DeliveryDetails", "EquipmentRestock")
                        .WithMany()
                        .HasForeignKey("EquipmentRestockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.EquipmentRestockRequest", b =>
                {
                    b.HasOne("Attila.Domain.Entities.EquipmentDetails", "EquipmentDetails")
                        .WithMany()
                        .HasForeignKey("EquipmentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.EventAdditionalDurationRequest", b =>
                {
                    b.HasOne("Attila.Domain.Entities.EventDetails", "EventDetails")
                        .WithMany()
                        .HasForeignKey("EventDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.EventAdditionalEquipmentRequest", b =>
                {
                    b.HasOne("Attila.Domain.Entities.EquipmentDetails", "EquipmentDetails")
                        .WithMany()
                        .HasForeignKey("EquipmentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.EventDetails", "EventDetails")
                        .WithMany()
                        .HasForeignKey("EventDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.EventDetails", b =>
                {
                    b.HasOne("Attila.Domain.Entities.ClientDetails", "EventClient")
                        .WithMany()
                        .HasForeignKey("EventClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.PackageMenuDetails", "PackageDetails")
                        .WithMany()
                        .HasForeignKey("PackageDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.EventMenus", b =>
                {
                    b.HasOne("Attila.Domain.Entities.EventDetails", "EventDetails")
                        .WithMany()
                        .HasForeignKey("EventDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.FoodInventory", b =>
                {
                    b.HasOne("Attila.Domain.Entities.FoodDetails", "FoodDetails")
                        .WithMany()
                        .HasForeignKey("FoodDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.DeliveryDetails", "FoodRestock")
                        .WithMany()
                        .HasForeignKey("FoodRestockID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.FoodRestockRequest", b =>
                {
                    b.HasOne("Attila.Domain.Entities.FoodDetails", "FoodDetails")
                        .WithMany()
                        .HasForeignKey("FoodDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.Menu", b =>
                {
                    b.HasOne("Attila.Domain.Entities.MenuCategory", "MenuCategory")
                        .WithMany()
                        .HasForeignKey("MenuCategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.PackageEquipments", b =>
                {
                    b.HasOne("Attila.Domain.Entities.EquipmentDetails", "EquipmentDetails")
                        .WithMany()
                        .HasForeignKey("EquipmentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.PackageMenuDetails", "PackageMenuDetails")
                        .WithMany()
                        .HasForeignKey("PackageMenuDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.PackageMenus", b =>
                {
                    b.HasOne("Attila.Domain.Entities.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.PackageMenuDetails", "PackageMenuDetails")
                        .WithMany()
                        .HasForeignKey("PackageMenuDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.PaymentStatus", b =>
                {
                    b.HasOne("Attila.Domain.Entities.EventDetails", "EventDetails")
                        .WithMany()
                        .HasForeignKey("EventDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.EventEquipments", b =>
                {
                    b.HasOne("Attila.Domain.Entities.EquipmentDetails", "EquipmentDetails")
                        .WithMany()
                        .HasForeignKey("EquipmentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Attila.Domain.Entities.EventDetails", "EventDetails")
                        .WithMany()
                        .HasForeignKey("EventDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.UserLogins", b =>
                {
                    b.HasOne("Attila.Domain.Entities.User", "User")
                        .WithOne("UserLogins")
                        .HasForeignKey("Attila.Domain.Entities.UserLogins", "ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
