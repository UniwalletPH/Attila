﻿// <auto-generated />
using System;
using Attila.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Attila.Infrastructure.Migrations
{
    [DbContext(typeof(AttilaDbContext))]
    [Migration("20200204083554_new-db")]
    partial class newdb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

                    b.ToTable("tbl_EquipmentRestockRequest");
                });

            modelBuilder.Entity("Attila.Domain.Entities.EventEquipmentRequest", b =>
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

                    b.ToTable("tbl_EventEquipmentRequest");
                });

            modelBuilder.Entity("Attila.Domain.Entities.FoodRestockRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTimeRequest")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FoodDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("FoodsDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("FoodDetailsID");

                    b.ToTable("tbl_FoodRestockRequest");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.EquipmentDelivery", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DeliveryPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte[]>("ReceiptImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("tbl_EquipmentDelivery");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.EquipmentDetails", b =>
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

                    b.Property<byte>("UnitType")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.ToTable("tbl_EquipmentDetails");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.EquipmentInventory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EncodingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EquipmentDeliveryID")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentDetailsID")
                        .HasColumnType("int");

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("tbl_EquipmentInventory");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.EventClient", b =>
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

                    b.ToTable("tbl_EventClient");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.EventDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EventDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventEquipmentsID")
                        .HasColumnType("int");

                    b.Property<string>("EventName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventPackageDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("EventPaymentStatusID")
                        .HasColumnType("int");

                    b.Property<byte>("EventStatus")
                        .HasColumnType("tinyint");

                    b.Property<int>("EventTeamID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PackageAdditionalDurationRequestID")
                        .HasColumnType("int");

                    b.Property<int>("PackageAdditionalEquipmentRequestID")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Type")
                        .HasColumnType("tinyint");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("tbl_EventDetails");
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

                    b.ToTable("tbl_EventEquipments");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.EventPackageDetails", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("NumberOfGuest")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("tbl_EventPackageDetails");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.EventPaymentStatus", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateOfPayment")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReferenceNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("tbl_EventPaymentStatus");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.FoodDetails", b =>
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

                    b.ToTable("tbl_FoodDetails");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.FoodInventory", b =>
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
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("tbl_FoodInventory");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.FoodRestock", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("DeliveryPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DeliveryTime")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("RecieptImage")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("tbl_FoodRestock");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.PackageAdditionalDurationRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<int>("EventDetailsID")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.ToTable("tbl_PackageAdditionalDurationRequest");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.PackageAdditionalEquipmentRequest", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EquipmentDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("EquipmentsDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("EventDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("ID");

                    b.HasIndex("EquipmentDetailsID");

                    b.ToTable("tbl_PackageAdditionalEquipmentRequest");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.User", b =>
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

                    b.ToTable("tbl_User");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.UserMap", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventDetailsID")
                        .HasColumnType("int");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("tbl_UserMap");
                });

            modelBuilder.Entity("Attila.Domain.Entities.EquipmentRestockRequest", b =>
                {
                    b.HasOne("Attila.Domain.Entities.Tables.EquipmentDetails", "EquipmentDetails")
                        .WithMany()
                        .HasForeignKey("EquipmentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.EventEquipmentRequest", b =>
                {
                    b.HasOne("Attila.Domain.Entities.Tables.EquipmentDetails", "EquipmentDetails")
                        .WithMany()
                        .HasForeignKey("EquipmentDetailsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Attila.Domain.Entities.FoodRestockRequest", b =>
                {
                    b.HasOne("Attila.Domain.Entities.Tables.FoodDetails", "FoodDetails")
                        .WithMany()
                        .HasForeignKey("FoodDetailsID");
                });

            modelBuilder.Entity("Attila.Domain.Entities.Tables.PackageAdditionalEquipmentRequest", b =>
                {
                    b.HasOne("Attila.Domain.Entities.Tables.EquipmentDetails", "EquipmentDetails")
                        .WithMany()
                        .HasForeignKey("EquipmentDetailsID");
                });
#pragma warning restore 612, 618
        }
    }
}
