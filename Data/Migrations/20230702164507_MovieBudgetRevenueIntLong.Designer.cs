﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using goblin_cheese.Data;

#nullable disable

namespace goblin_cheese.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230702164507_MovieBudgetRevenueIntLong")]
    partial class MovieBudgetRevenueIntLong
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("integer");

                    b.Property<int>("GenreId")
                        .HasColumnType("integer");

                    b.HasKey("GamesId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GameGenre");
                });

            modelBuilder.Entity("GameGoblinUser", b =>
                {
                    b.Property<string>("FavedById")
                        .HasColumnType("text");

                    b.Property<int>("FavouriteGamesId")
                        .HasColumnType("integer");

                    b.HasKey("FavedById", "FavouriteGamesId");

                    b.HasIndex("FavouriteGamesId");

                    b.ToTable("GameGoblinUser");
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

            modelBuilder.Entity("goblin_cheese.Areas.Identity.Data.GoblinUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FullName")
                        .HasColumnType("text");

                    b.Property<string>("GoblinName")
                        .HasColumnType("text");

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

                    b.Property<DateTime?>("SignupDate")
                        .HasColumnType("timestamp with time zone");

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
                });

            modelBuilder.Entity("goblin_cheese.Models.Game.Game", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("CoverUrl")
                        .HasColumnType("text");

                    b.Property<string>("Opinion")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("Summary")
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("goblin_cheese.Models.Game.Genre", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Game_Genre");
                });

            modelBuilder.Entity("goblin_cheese.Models.Game.Screenshot", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<int?>("GameId")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Game_Screenshot");
                });

            modelBuilder.Entity("goblin_cheese.Models.Movie.Backdrop", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<string>("ContentType")
                        .HasColumnType("text");

                    b.Property<byte[]>("Data")
                        .HasColumnType("bytea");

                    b.HasKey("MovieId");

                    b.ToTable("Movie_Backdrop");
                });

            modelBuilder.Entity("goblin_cheese.Models.Movie.Movie", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("integer");

                    b.Property<long?>("Budget")
                        .HasColumnType("bigint");

                    b.Property<string>("Overview")
                        .HasColumnType("text");

                    b.Property<DateOnly?>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<long?>("Revenue")
                        .HasColumnType("bigint");

                    b.Property<int?>("Runtime")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Movie");
                });

            modelBuilder.Entity("goblin_cheese.Models.Movie.Poster", b =>
                {
                    b.Property<int>("MovieId")
                        .HasColumnType("integer");

                    b.Property<string>("ContentType")
                        .HasColumnType("text");

                    b.Property<byte[]>("Data")
                        .HasColumnType("bytea");

                    b.HasKey("MovieId");

                    b.ToTable("Movie_Poster");
                });

            modelBuilder.Entity("GameGenre", b =>
                {
                    b.HasOne("goblin_cheese.Models.Game.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("goblin_cheese.Models.Game.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameGoblinUser", b =>
                {
                    b.HasOne("goblin_cheese.Areas.Identity.Data.GoblinUser", null)
                        .WithMany()
                        .HasForeignKey("FavedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("goblin_cheese.Models.Game.Game", null)
                        .WithMany()
                        .HasForeignKey("FavouriteGamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
                    b.HasOne("goblin_cheese.Areas.Identity.Data.GoblinUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("goblin_cheese.Areas.Identity.Data.GoblinUser", null)
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

                    b.HasOne("goblin_cheese.Areas.Identity.Data.GoblinUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("goblin_cheese.Areas.Identity.Data.GoblinUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("goblin_cheese.Models.Game.Screenshot", b =>
                {
                    b.HasOne("goblin_cheese.Models.Game.Game", "Game")
                        .WithMany("Screenshots")
                        .HasForeignKey("GameId");

                    b.Navigation("Game");
                });

            modelBuilder.Entity("goblin_cheese.Models.Movie.Backdrop", b =>
                {
                    b.HasOne("goblin_cheese.Models.Movie.Movie", "Movie")
                        .WithMany("Backdrops")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("goblin_cheese.Models.Movie.Poster", b =>
                {
                    b.HasOne("goblin_cheese.Models.Movie.Movie", "Movie")
                        .WithOne("Poster")
                        .HasForeignKey("goblin_cheese.Models.Movie.Poster", "MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("goblin_cheese.Models.Game.Game", b =>
                {
                    b.Navigation("Screenshots");
                });

            modelBuilder.Entity("goblin_cheese.Models.Movie.Movie", b =>
                {
                    b.Navigation("Backdrops");

                    b.Navigation("Poster");
                });
#pragma warning restore 612, 618
        }
    }
}
