﻿// <auto-generated />
using System;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Domain.Migrations
{
    [DbContext(typeof(ApiDBContext))]
    partial class ApiDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Models.Cart", b =>
                {
                    b.Property<int>("CartsId")
                        .HasColumnType("int")
                        .HasColumnName("carts_id");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("CartsId");

                    b.HasIndex("IdUser");

                    b.HasIndex("ItemId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("category_name");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.HasKey("CategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Domain.Models.Delivery", b =>
                {
                    b.Property<int>("DeliveryId")
                        .HasColumnType("int")
                        .HasColumnName("delivery_id");

                    b.Property<string>("DeliveryType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("delivery_type");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.HasKey("DeliveryId");

                    b.ToTable("Delivery", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("date")
                        .HasColumnName("date");

                    b.Property<int>("DeliveryId")
                        .HasColumnType("int")
                        .HasColumnName("delivery_id");

                    b.Property<int>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.HasKey("OrderId");

                    b.HasIndex("DeliveryId");

                    b.HasIndex("IdUser");

                    b.HasIndex("StatusId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Domain.Models.OrdersItem", b =>
                {
                    b.Property<int>("OrderItemId")
                        .HasColumnType("int")
                        .HasColumnName("order_item_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("order_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("int")
                        .HasColumnName("quantity");

                    b.HasKey("OrderItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("Orders_item", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("ItemDescription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("item_description");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("item_name");

                    b.Property<int?>("Price")
                        .HasColumnType("int")
                        .HasColumnName("price");

                    b.Property<int>("WarehouseQuantity")
                        .HasColumnType("int")
                        .HasColumnName("warehouse_quantity");

                    b.HasKey("ItemId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Domain.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("role_name");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Domain.Models.Spec", b =>
                {
                    b.Property<int>("SpecId")
                        .HasColumnType("int")
                        .HasColumnName("spec_id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("category_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("SpecName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("spec_name");

                    b.HasKey("SpecId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Specs");
                });

            modelBuilder.Entity("Domain.Models.SpecsItem", b =>
                {
                    b.Property<int>("SpecItemId")
                        .HasColumnType("int")
                        .HasColumnName("spec_item_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<int>("ItemId")
                        .HasColumnType("int")
                        .HasColumnName("item_id");

                    b.Property<int>("SpecId")
                        .HasColumnType("int")
                        .HasColumnName("spec_id");

                    b.Property<string>("SpecValue")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("spec_value");

                    b.HasKey("SpecItemId");

                    b.HasIndex("ItemId");

                    b.HasIndex("SpecId");

                    b.ToTable("Specs_item", (string)null);
                });

            modelBuilder.Entity("Domain.Models.Status", b =>
                {
                    b.Property<int>("StatusId")
                        .HasColumnType("int")
                        .HasColumnName("status_id");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("StatusType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("status_type");

                    b.HasKey("StatusId");

                    b.ToTable("Status", (string)null);
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Property<int>("id_user")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("address");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("password");

                    b.Property<int>("RoleId")
                        .HasColumnType("int")
                        .HasColumnName("role_id");

                    b.HasKey("id_user");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Domain.Models.Cart", b =>
                {
                    b.HasOne("Domain.Models.User", "IdUserNavigation")
                        .WithMany("Carts")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_UserCarts");

                    b.HasOne("Domain.Models.Product", "Item")
                        .WithMany("Carts")
                        .HasForeignKey("ItemId")
                        .IsRequired()
                        .HasConstraintName("FK_ItemsCarts");

                    b.Navigation("IdUserNavigation");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Domain.Models.Order", b =>
                {
                    b.HasOne("Domain.Models.Delivery", "Delivery")
                        .WithMany("Orders")
                        .HasForeignKey("DeliveryId")
                        .IsRequired()
                        .HasConstraintName("FK_Delivery");

                    b.HasOne("Domain.Models.User", "IdUserNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("IdUser")
                        .IsRequired()
                        .HasConstraintName("FK_UsersOrders");

                    b.HasOne("Domain.Models.Status", "Status")
                        .WithMany("Orders")
                        .HasForeignKey("StatusId")
                        .IsRequired()
                        .HasConstraintName("FK_Status");

                    b.Navigation("Delivery");

                    b.Navigation("IdUserNavigation");

                    b.Navigation("Status");
                });

            modelBuilder.Entity("Domain.Models.OrdersItem", b =>
                {
                    b.HasOne("Domain.Models.Product", "Item")
                        .WithMany("OrdersItems")
                        .HasForeignKey("ItemId")
                        .IsRequired()
                        .HasConstraintName("FK_ItemsOrders_item");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.HasOne("Domain.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .HasConstraintName("FK_Products_Categories");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Models.Spec", b =>
                {
                    b.HasOne("Domain.Models.Category", "Category")
                        .WithMany("Specs")
                        .HasForeignKey("CategoryId")
                        .IsRequired()
                        .HasConstraintName("FK_Specs_Categories");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Domain.Models.SpecsItem", b =>
                {
                    b.HasOne("Domain.Models.Product", "Item")
                        .WithMany("SpecsItems")
                        .HasForeignKey("ItemId")
                        .IsRequired()
                        .HasConstraintName("FK_ItemsSpecs_item");

                    b.HasOne("Domain.Models.Spec", "Spec")
                        .WithMany("SpecsItems")
                        .HasForeignKey("SpecId")
                        .IsRequired()
                        .HasConstraintName("FK_SpecsSpecs_item");

                    b.Navigation("Item");

                    b.Navigation("Spec");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.HasOne("Domain.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .IsRequired()
                        .HasConstraintName("FK_Users_Roles");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Domain.Models.Category", b =>
                {
                    b.Navigation("Products");

                    b.Navigation("Specs");
                });

            modelBuilder.Entity("Domain.Models.Delivery", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Models.Product", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("OrdersItems");

                    b.Navigation("SpecsItems");
                });

            modelBuilder.Entity("Domain.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Domain.Models.Spec", b =>
                {
                    b.Navigation("SpecsItems");
                });

            modelBuilder.Entity("Domain.Models.Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Domain.Models.User", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
