﻿// <auto-generated />
using System;
using MegaStore.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MegaStore.API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("MegaStore.API.Models.Core.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("mscId");

                    b.Property<string>("countryCode")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("mscCountryCode");

                    b.Property<string>("countryName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("mscCountryName");

                    b.Property<DateTime>("creationDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("mscCreationDate");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("mscCreationUserId");

                    b.HasKey("id");

                    b.ToTable("mscCountry");
                });

            modelBuilder.Entity("MegaStore.API.Models.Core.Module", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("mscmId");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("TEXT")
                        .HasColumnName("mscmCreateAt");

                    b.Property<string>("modulueName")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("mscmModuleName");

                    b.Property<bool>("status")
                        .HasColumnType("INTEGER")
                        .HasColumnName("mscmStatus");

                    b.HasKey("id");

                    b.ToTable("mscModule");
                });

            modelBuilder.Entity("MegaStore.API.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("MegaStore.API.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("BLOB");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MegaStore.API.Models.Photo", b =>
                {
                    b.HasOne("MegaStore.API.Models.User", "User")
                        .WithMany("Photos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MegaStore.API.Models.User", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
