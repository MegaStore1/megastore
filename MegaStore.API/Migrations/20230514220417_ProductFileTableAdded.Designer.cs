﻿// <auto-generated />
using System;
using MegaStore.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MegaStore.API.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230514220417_ProductFileTableAdded")]
    partial class ProductFileTableAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.3");

            modelBuilder.Entity("MegaStore.API.Models.Core.CountryModel.Country", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("countryCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("countryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("mscCountry");
                });

            modelBuilder.Entity("MegaStore.API.Models.Core.CountryModel.State", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("countryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("stateCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("stateName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("countryId");

                    b.ToTable("mscState");
                });

            modelBuilder.Entity("MegaStore.API.Models.Core.Module", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("moduleName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("mscModule");
                });

            modelBuilder.Entity("MegaStore.API.Models.Core.ModulePage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("moduleId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("pageName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("moduleId");

                    b.ToTable("mscModulePage");
                });

            modelBuilder.Entity("MegaStore.API.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("msuPhoto");
                });

            modelBuilder.Entity("MegaStore.API.Models.Product.Product.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("plantId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("plantId");

                    b.ToTable("mspCategory");
                });

            modelBuilder.Entity("MegaStore.API.Models.Product.Product.Color", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("colorName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("plantId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("plantId");

                    b.ToTable("mspColor");
                });

            modelBuilder.Entity("MegaStore.API.Models.Product.Product.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("categoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("colorId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("categoryId");

                    b.HasIndex("colorId");

                    b.ToTable("mspProduct");
                });

            modelBuilder.Entity("MegaStore.API.Models.Product.Product.ProductFile", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("contentType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("fileLength")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("fileName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("fileType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("productId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasDefaultValue(true);

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("productId");

                    b.ToTable("mspProductFile");
                });

            modelBuilder.Entity("MegaStore.API.Models.Settings.Company.Company", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("companyName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.ToTable("msstCompany");
                });

            modelBuilder.Entity("MegaStore.API.Models.Settings.Company.Plant", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("companyId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("lat")
                        .HasColumnType("INTEGER");

                    b.Property<long>("lng")
                        .HasColumnType("INTEGER");

                    b.Property<string>("plantName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("stateId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("id");

                    b.HasIndex("companyId");

                    b.HasIndex("stateId");

                    b.ToTable("msstPlant");
                });

            modelBuilder.Entity("MegaStore.API.Models.Shared.UserRoles", b =>
                {
                    b.Property<int>("pageId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("userId")
                        .HasColumnType("INTEGER");

                    b.HasKey("pageId", "userId");

                    b.HasIndex("userId");

                    b.ToTable("mssUserRoles");
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

                    b.Property<DateTime>("creationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("creationUserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("plantId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("status")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("updateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<int>("updateUserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("plantId");

                    b.ToTable("msuUser");
                });

            modelBuilder.Entity("MegaStore.API.Models.Core.CountryModel.State", b =>
                {
                    b.HasOne("MegaStore.API.Models.Core.CountryModel.Country", "country")
                        .WithMany("States")
                        .HasForeignKey("countryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");
                });

            modelBuilder.Entity("MegaStore.API.Models.Core.ModulePage", b =>
                {
                    b.HasOne("MegaStore.API.Models.Core.Module", "module")
                        .WithMany("pages")
                        .HasForeignKey("moduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("module");
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

            modelBuilder.Entity("MegaStore.API.Models.Product.Product.Category", b =>
                {
                    b.HasOne("MegaStore.API.Models.Settings.Company.Plant", "plant")
                        .WithMany("categories")
                        .HasForeignKey("plantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plant");
                });

            modelBuilder.Entity("MegaStore.API.Models.Product.Product.Color", b =>
                {
                    b.HasOne("MegaStore.API.Models.Settings.Company.Plant", "plant")
                        .WithMany("colors")
                        .HasForeignKey("plantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plant");
                });

            modelBuilder.Entity("MegaStore.API.Models.Product.Product.Product", b =>
                {
                    b.HasOne("MegaStore.API.Models.Product.Product.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaStore.API.Models.Product.Product.Color", "color")
                        .WithMany("products")
                        .HasForeignKey("colorId");

                    b.Navigation("category");

                    b.Navigation("color");
                });

            modelBuilder.Entity("MegaStore.API.Models.Product.Product.ProductFile", b =>
                {
                    b.HasOne("MegaStore.API.Models.Product.Product.Product", "product")
                        .WithMany("files")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("MegaStore.API.Models.Settings.Company.Plant", b =>
                {
                    b.HasOne("MegaStore.API.Models.Settings.Company.Company", "company")
                        .WithMany("plants")
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaStore.API.Models.Core.CountryModel.State", "state")
                        .WithMany("plants")
                        .HasForeignKey("stateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");

                    b.Navigation("state");
                });

            modelBuilder.Entity("MegaStore.API.Models.Shared.UserRoles", b =>
                {
                    b.HasOne("MegaStore.API.Models.Core.ModulePage", "page")
                        .WithMany()
                        .HasForeignKey("pageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MegaStore.API.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("page");

                    b.Navigation("user");
                });

            modelBuilder.Entity("MegaStore.API.Models.User", b =>
                {
                    b.HasOne("MegaStore.API.Models.Settings.Company.Plant", "plant")
                        .WithMany("Users")
                        .HasForeignKey("plantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("plant");
                });

            modelBuilder.Entity("MegaStore.API.Models.Core.CountryModel.Country", b =>
                {
                    b.Navigation("States");
                });

            modelBuilder.Entity("MegaStore.API.Models.Core.CountryModel.State", b =>
                {
                    b.Navigation("plants");
                });

            modelBuilder.Entity("MegaStore.API.Models.Core.Module", b =>
                {
                    b.Navigation("pages");
                });

            modelBuilder.Entity("MegaStore.API.Models.Product.Product.Color", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("MegaStore.API.Models.Product.Product.Product", b =>
                {
                    b.Navigation("files");
                });

            modelBuilder.Entity("MegaStore.API.Models.Settings.Company.Company", b =>
                {
                    b.Navigation("plants");
                });

            modelBuilder.Entity("MegaStore.API.Models.Settings.Company.Plant", b =>
                {
                    b.Navigation("Users");

                    b.Navigation("categories");

                    b.Navigation("colors");
                });

            modelBuilder.Entity("MegaStore.API.Models.User", b =>
                {
                    b.Navigation("Photos");
                });
#pragma warning restore 612, 618
        }
    }
}
