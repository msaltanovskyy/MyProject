// <auto-generated />
using System;
using AutoStop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoStop.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220428083428_InitialPersistedGrantDbMigration")]
    partial class InitialPersistedGrantDbMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AutoStop.Models.BlackList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BlackList");
                });

            modelBuilder.Entity("AutoStop.Models.BusyPlaces", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("BusyPlace")
                        .HasColumnType("integer");

                    b.Property<int>("TravelId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("TravelId");

                    b.ToTable("BusyPlaces");
                });

            modelBuilder.Entity("AutoStop.Models.CarCategories", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<int>("CategoriesId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CategoriesId");

                    b.ToTable("CarCategories");
                });

            modelBuilder.Entity("AutoStop.Models.Cars", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Number"));

                    b.Property<int>("Chair")
                        .HasColumnType("integer");

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("DriverId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("FavoriteLisetId")
                        .HasColumnType("integer");

                    b.Property<int>("FavoriteListid")
                        .HasColumnType("integer");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Number");

                    b.HasIndex("DriverId");

                    b.HasIndex("FavoriteListid");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("AutoStop.Models.CategoriesCar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AutoStop.Models.Comments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("AccountsId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Comment")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("TravelsId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AccountsId");

                    b.HasIndex("TravelsId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("AutoStop.Models.FavoriteList", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("id"));

                    b.Property<string>("AccountId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("AccountId");

                    b.ToTable("FavoriteList");
                });

            modelBuilder.Entity("AutoStop.Models.PointArrive", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PointName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("PointArrives");
                });

            modelBuilder.Entity("AutoStop.Models.PointSend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("PointName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("PointSends");
                });

            modelBuilder.Entity("AutoStop.Models.Travels", b =>
                {
                    b.Property<int>("Number")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Number"));

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("integer");

                    b.Property<int>("CarId")
                        .HasColumnType("integer");

                    b.Property<decimal>("Cost")
                        .HasColumnType("numeric");

                    b.Property<string>("CreaterId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PointArriveId")
                        .HasColumnType("integer");

                    b.Property<int>("PointSendId")
                        .HasColumnType("integer");

                    b.Property<bool>("Status")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("TimeArrive")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("TimeCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("TimeSend")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Number");

                    b.HasIndex("CarId");

                    b.HasIndex("CreaterId");

                    b.HasIndex("PointArriveId");

                    b.HasIndex("PointSendId");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("character varying(128)");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("AutoStop.Models.Accounts", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<int>("BlackListId")
                        .HasColumnType("integer");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Nikcname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasIndex("BlackListId")
                        .IsUnique();

                    b.HasDiscriminator().HasValue("Accounts");
                });

            modelBuilder.Entity("AutoStop.Models.BusyPlaces", b =>
                {
                    b.HasOne("AutoStop.Models.Accounts", "Accounts")
                        .WithMany("BusyPlaces")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoStop.Models.Travels", "Traverl")
                        .WithMany("BusyPlaces")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");

                    b.Navigation("Traverl");
                });

            modelBuilder.Entity("AutoStop.Models.CarCategories", b =>
                {
                    b.HasOne("AutoStop.Models.Cars", "Car")
                        .WithMany("CarCategories")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoStop.Models.CategoriesCar", "Category")
                        .WithMany("CarCategories")
                        .HasForeignKey("CategoriesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AutoStop.Models.Cars", b =>
                {
                    b.HasOne("AutoStop.Models.Accounts", "Drivers")
                        .WithMany("Cars")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoStop.Models.FavoriteList", "FavoriteList")
                        .WithMany("Cars")
                        .HasForeignKey("FavoriteListid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Drivers");

                    b.Navigation("FavoriteList");
                });

            modelBuilder.Entity("AutoStop.Models.Comments", b =>
                {
                    b.HasOne("AutoStop.Models.Accounts", "Accounts")
                        .WithMany("Comments")
                        .HasForeignKey("AccountsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoStop.Models.Travels", "Travels")
                        .WithMany("Comments")
                        .HasForeignKey("TravelsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");

                    b.Navigation("Travels");
                });

            modelBuilder.Entity("AutoStop.Models.FavoriteList", b =>
                {
                    b.HasOne("AutoStop.Models.Accounts", "Accounts")
                        .WithMany("FavoriteLists")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("AutoStop.Models.Travels", b =>
                {
                    b.HasOne("AutoStop.Models.Cars", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoStop.Models.Accounts", "Creater")
                        .WithMany("Travels")
                        .HasForeignKey("CreaterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoStop.Models.PointArrive", "PointArrive")
                        .WithMany("Travels")
                        .HasForeignKey("PointArriveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AutoStop.Models.PointSend", "PointSend")
                        .WithMany("Travels")
                        .HasForeignKey("PointSendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Creater");

                    b.Navigation("PointArrive");

                    b.Navigation("PointSend");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AutoStop.Models.Accounts", b =>
                {
                    b.HasOne("AutoStop.Models.BlackList", "BlackList")
                        .WithOne("Accounts")
                        .HasForeignKey("AutoStop.Models.Accounts", "BlackListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BlackList");
                });

            modelBuilder.Entity("AutoStop.Models.BlackList", b =>
                {
                    b.Navigation("Accounts")
                        .IsRequired();
                });

            modelBuilder.Entity("AutoStop.Models.Cars", b =>
                {
                    b.Navigation("CarCategories");
                });

            modelBuilder.Entity("AutoStop.Models.CategoriesCar", b =>
                {
                    b.Navigation("CarCategories");
                });

            modelBuilder.Entity("AutoStop.Models.FavoriteList", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("AutoStop.Models.PointArrive", b =>
                {
                    b.Navigation("Travels");
                });

            modelBuilder.Entity("AutoStop.Models.PointSend", b =>
                {
                    b.Navigation("Travels");
                });

            modelBuilder.Entity("AutoStop.Models.Travels", b =>
                {
                    b.Navigation("BusyPlaces");

                    b.Navigation("Comments");
                });

            modelBuilder.Entity("AutoStop.Models.Accounts", b =>
                {
                    b.Navigation("BusyPlaces");

                    b.Navigation("Cars");

                    b.Navigation("Comments");

                    b.Navigation("FavoriteLists");

                    b.Navigation("Travels");
                });
#pragma warning restore 612, 618
        }
    }
}
