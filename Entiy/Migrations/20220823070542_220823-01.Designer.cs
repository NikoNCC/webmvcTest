﻿// <auto-generated />
using System;
using Entiy;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Entiy.Migrations
{
    [DbContext(typeof(StorehouseSysDbContext))]
    [Migration("20220823070542_220823-01")]
    partial class _22082301
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Entity.Category", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Entity.ConsumableInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("CategoryId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ConsumableName")
                        .IsRequired()
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Num")
                        .HasColumnType("int");

                    b.Property<string>("Specification")
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Unit")
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("WarningNum")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ConsumableInfo");
                });

            modelBuilder.Entity("Entity.ConsumableRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ConsumableId")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Num")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ConsumableRecord");
                });

            modelBuilder.Entity("Entity.R_RoleInfo_MenuInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MenuId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.ToTable("R_RoleInfo_MenuInfo");
                });

            modelBuilder.Entity("Entiy.DepartmentInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(32)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LeaderId")
                        .HasColumnType("nvarchar(36)");

                    b.Property<string>("ParentId")
                        .HasColumnType("nvarchar(36)");

                    b.HasKey("Id");

                    b.ToTable("DepartmentInfo");
                });

            modelBuilder.Entity("Entiy.MenuInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Href")
                        .HasColumnType("varchar(128)");

                    b.Property<string>("Icon")
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<string>("ParentId")
                        .HasColumnType("varchar(36)");

                    b.Property<int>("Sort")
                        .HasColumnType("int");

                    b.Property<string>("Target")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(16)");

                    b.HasKey("Id");

                    b.ToTable("MenuInfo");
                });

            modelBuilder.Entity("Entiy.R_UserInfo_RoleInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("UserId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.ToTable("R_UserInfo_RoleInfo");
                });

            modelBuilder.Entity("Entiy.RoleInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .HasColumnType("varchar(16)");

                    b.HasKey("Id");

                    b.ToTable("RoleInfo");
                });

            modelBuilder.Entity("Entiy.UserInfo", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Account")
                        .HasColumnType("varchar(16)");

                    b.Property<DateTime>("CreateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DeleteTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("PassWord")
                        .HasColumnType("varchar(32)");

                    b.Property<string>("PhoneNum")
                        .HasColumnType("varchar(16)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.ToTable("UserInfo");
                });
#pragma warning restore 612, 618
        }
    }
}
