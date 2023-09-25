﻿// <auto-generated />
using System;
using CarRental.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CarRental.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230925173033_Create_Database")]
    partial class Create_Database
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CarRental.Domain.Bookings.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime?>("CancelledOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("cancelled_on_utc");

                    b.Property<DateTime?>("CompletedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("completed_on_utc");

                    b.Property<DateTime?>("ConfirmedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("confirmed_on_utc");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on_utc");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<DateTime?>("RejectedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("rejected_on_utc");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("status");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uuid")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id")
                        .HasName("pk_bookings");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_bookings_customer_id");

                    b.HasIndex("VehicleId")
                        .HasDatabaseName("ix_bookings_vehicle_id");

                    b.ToTable("bookings", (string)null);
                });

            modelBuilder.Entity("CarRental.Domain.Customers.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("character varying(400)")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("first_name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("last_name");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)")
                        .HasColumnName("phone");

                    b.HasKey("Id")
                        .HasName("pk_customers");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("ix_customers_email");

                    b.ToTable("customers", (string)null);
                });

            modelBuilder.Entity("CarRental.Domain.Reviews.Review", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("BookingId")
                        .HasColumnType("uuid")
                        .HasColumnName("booking_id");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("comment");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on_utc");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid")
                        .HasColumnName("customer_id");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<Guid>("VehicleId")
                        .HasColumnType("uuid")
                        .HasColumnName("vehicle_id");

                    b.HasKey("Id")
                        .HasName("pk_reviews");

                    b.HasIndex("BookingId")
                        .HasDatabaseName("ix_reviews_booking_id");

                    b.HasIndex("CustomerId")
                        .HasDatabaseName("ix_reviews_customer_id");

                    b.HasIndex("VehicleId")
                        .HasDatabaseName("ix_reviews_vehicle_id");

                    b.ToTable("reviews", (string)null);
                });

            modelBuilder.Entity("CarRental.Domain.Vehicles.Brands.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("BrandName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("brand_name");

                    b.Property<Guid>("ModelId")
                        .HasColumnType("uuid")
                        .HasColumnName("model_id");

                    b.HasKey("Id")
                        .HasName("pk_brands");

                    b.HasIndex("ModelId")
                        .HasDatabaseName("ix_brands_model_id");

                    b.ToTable("brands", (string)null);
                });

            modelBuilder.Entity("CarRental.Domain.Vehicles.Models.Model", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("ModelName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("model_name");

                    b.HasKey("Id")
                        .HasName("pk_models");

                    b.ToTable("models", (string)null);
                });

            modelBuilder.Entity("CarRental.Domain.Vehicles.Vehicle", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int[]>("Amenities")
                        .IsRequired()
                        .HasColumnType("integer[]")
                        .HasColumnName("amenities");

                    b.Property<Guid?>("BrandId")
                        .HasColumnType("uuid")
                        .HasColumnName("brand_id");

                    b.Property<DateTime>("CreatedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_on_utc");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("character varying(2000)")
                        .HasColumnName("description");

                    b.Property<DateTime?>("LastBookedOnUtc")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_booked_on_utc");

                    b.Property<string>("Plate")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("plate");

                    b.Property<uint>("Version")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("xid")
                        .HasColumnName("xmin");

                    b.HasKey("Id")
                        .HasName("pk_vehicles");

                    b.HasIndex("BrandId")
                        .HasDatabaseName("ix_vehicles_brand_id");

                    b.ToTable("vehicles", (string)null);
                });

            modelBuilder.Entity("CarRental.Domain.Bookings.Booking", b =>
                {
                    b.HasOne("CarRental.Domain.Customers.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_customer_customer_temp_id");

                    b.HasOne("CarRental.Domain.Vehicles.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_bookings_vehicle_vehicle_temp_id");

                    b.OwnsOne("CarRental.Domain.Shared.Money", "AmenitiesUpCharge", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("amenities_up_charge_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("amenities_up_charge_currency");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId")
                                .HasConstraintName("fk_bookings_bookings_id");
                        });

                    b.OwnsOne("CarRental.Domain.Shared.Money", "PriceForPeriod", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("price_for_period_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("price_for_period_currency");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId")
                                .HasConstraintName("fk_bookings_bookings_id");
                        });

                    b.OwnsOne("CarRental.Domain.Shared.Money", "TotalPrice", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("total_price_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("total_price_currency");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId")
                                .HasConstraintName("fk_bookings_bookings_id");
                        });

                    b.OwnsOne("CarRental.Domain.Bookings.DateRange", "Duration", b1 =>
                        {
                            b1.Property<Guid>("BookingId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateTime>("End")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("duration_end");

                            b1.Property<DateTime>("Start")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("duration_start");

                            b1.HasKey("BookingId");

                            b1.ToTable("bookings");

                            b1.WithOwner()
                                .HasForeignKey("BookingId")
                                .HasConstraintName("fk_bookings_bookings_id");
                        });

                    b.Navigation("AmenitiesUpCharge")
                        .IsRequired();

                    b.Navigation("Duration")
                        .IsRequired();

                    b.Navigation("PriceForPeriod")
                        .IsRequired();

                    b.Navigation("TotalPrice")
                        .IsRequired();
                });

            modelBuilder.Entity("CarRental.Domain.Reviews.Review", b =>
                {
                    b.HasOne("CarRental.Domain.Bookings.Booking", null)
                        .WithMany()
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_bookings_booking_id1");

                    b.HasOne("CarRental.Domain.Customers.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_customers_customer_id1");

                    b.HasOne("CarRental.Domain.Vehicles.Vehicle", null)
                        .WithMany()
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_vehicle_vehicle_temp_id");
                });

            modelBuilder.Entity("CarRental.Domain.Vehicles.Brands.Brand", b =>
                {
                    b.HasOne("CarRental.Domain.Vehicles.Models.Model", null)
                        .WithMany()
                        .HasForeignKey("ModelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_brands_model_model_temp_id");
                });

            modelBuilder.Entity("CarRental.Domain.Vehicles.Vehicle", b =>
                {
                    b.HasOne("CarRental.Domain.Vehicles.Brands.Brand", null)
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .HasConstraintName("fk_vehicles_brands_brand_id1");

                    b.OwnsOne("CarRental.Domain.Vehicles.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("VehicleId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_city");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_country");

                            b1.Property<string>("MapLocation")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_map_location");

                            b1.Property<string>("State")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_state");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("address_street");

                            b1.HasKey("VehicleId");

                            b1.ToTable("vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehicleId")
                                .HasConstraintName("fk_vehicles_vehicles_id");
                        });

                    b.OwnsOne("CarRental.Domain.Shared.Money", "Price", b1 =>
                        {
                            b1.Property<Guid>("VehicleId")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<decimal>("Amount")
                                .HasColumnType("numeric")
                                .HasColumnName("price_amount");

                            b1.Property<string>("Currency")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("price_currency");

                            b1.HasKey("VehicleId");

                            b1.ToTable("vehicles");

                            b1.WithOwner()
                                .HasForeignKey("VehicleId")
                                .HasConstraintName("fk_vehicles_vehicles_id");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Price")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
