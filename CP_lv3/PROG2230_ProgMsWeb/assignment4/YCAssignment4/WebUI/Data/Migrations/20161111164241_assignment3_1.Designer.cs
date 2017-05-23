using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using WebUI.Data;

namespace WebUI.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161111164241_assignment3_1")]
    partial class assignment3_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WebUI.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("WebUI.Models.Branchs", b =>
                {
                    b.Property<int>("branchID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("branchName");

                    b.Property<string>("custAddress");

                    b.Property<string>("custCity");

                    b.Property<string>("custPhone");

                    b.Property<string>("custState");

                    b.Property<string>("custZip");

                    b.HasKey("branchID");

                    b.ToTable("Branchs");
                });

            modelBuilder.Entity("WebUI.Models.Customers", b =>
                {
                    b.Property<int>("customerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustEmail");

                    b.Property<string>("custAddress");

                    b.Property<string>("custCity");

                    b.Property<string>("custFName");

                    b.Property<string>("custLName");

                    b.Property<string>("custPhone");

                    b.Property<string>("custState");

                    b.Property<string>("custZip");

                    b.HasKey("customerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("WebUI.Models.Orders", b =>
                {
                    b.Property<int>("orderID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("OrderEmail");

                    b.Property<string>("custAddress");

                    b.Property<string>("custName");

                    b.Property<DateTime>("deliveryDate");

                    b.Property<string>("paymentMethod");

                    b.HasKey("orderID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebUI.Models.Products", b =>
                {
                    b.Property<int>("productID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("productImage");

                    b.Property<string>("productName");

                    b.Property<decimal>("productPrice");

                    b.HasKey("productID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("WebUI.Models.Qnas", b =>
                {
                    b.Property<int>("qnaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("content");

                    b.Property<DateTime>("createDate");

                    b.Property<int>("customerID");

                    b.Property<string>("title");

                    b.Property<int>("view");

                    b.HasKey("qnaId");

                    b.HasIndex("customerID");

                    b.ToTable("Qnas");
                });

            modelBuilder.Entity("WebUI.Models.Receipts", b =>
                {
                    b.Property<int>("receiptID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerscustomerID");

                    b.Property<int>("orderID");

                    b.Property<DateTime>("paymentDate");

                    b.Property<string>("paymentMethod");

                    b.HasKey("receiptID");

                    b.HasIndex("CustomerscustomerID");

                    b.HasIndex("orderID");

                    b.ToTable("Receipts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("WebUI.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("WebUI.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WebUI.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebUI.Models.Qnas", b =>
                {
                    b.HasOne("WebUI.Models.Customers", "CustomerIDNavigation")
                        .WithMany("Qnas")
                        .HasForeignKey("customerID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WebUI.Models.Receipts", b =>
                {
                    b.HasOne("WebUI.Models.Customers")
                        .WithMany("Receipts")
                        .HasForeignKey("CustomerscustomerID");

                    b.HasOne("WebUI.Models.Orders", "OrderIDNavigation")
                        .WithMany()
                        .HasForeignKey("orderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
