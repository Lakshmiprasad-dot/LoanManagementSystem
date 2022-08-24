﻿// <auto-generated />
using LoanManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LoanManagementSystem.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220824064937_Second")]
    partial class Second
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LoanManagementSystem.Models.LoanApplication", b =>
                {
                    b.Property<int>("LoanApplicationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationHolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("IfscCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("LoanAmount")
                        .HasColumnType("int");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.HasKey("LoanApplicationId");

                    b.HasIndex("LoanId");

                    b.ToTable("Loan_Applications");
                });

            modelBuilder.Entity("LoanManagementSystem.Models.LoanType", b =>
                {
                    b.Property<int>("LoanId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("LoanGivenTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LoanTypeName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("NumberOfGuaranters")
                        .HasColumnType("int");

                    b.HasKey("LoanId");

                    b.ToTable("Loan_Types");
                });

            modelBuilder.Entity("LoanManagementSystem.Models.RateOfInterest", b =>
                {
                    b.Property<int>("RateOfInterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("LoanAmount1")
                        .HasColumnType("int");

                    b.Property<int>("LoanAmount2")
                        .HasColumnType("int");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.HasKey("RateOfInterestId");

                    b.HasIndex("LoanId");

                    b.ToTable("Rate_Of_Interests");
                });

            modelBuilder.Entity("LoanManagementSystem.Models.LoanApplication", b =>
                {
                    b.HasOne("LoanManagementSystem.Models.LoanType", "LoanType")
                        .WithMany("LoanApplications")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LoanManagementSystem.Models.RateOfInterest", b =>
                {
                    b.HasOne("LoanManagementSystem.Models.LoanType", "LoanType")
                        .WithMany("RateOfInterests")
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}