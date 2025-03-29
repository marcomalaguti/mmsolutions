﻿// <auto-generated />
using System;
using MMS.Erp.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MMS.Erp.Infrastructure.Migrations
{
    [DbContext(typeof(ErpDbContext))]
    [Migration("20250329190049_rel")]
    partial class rel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MMS.Erp.Domain.AggregateRoots.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("MMS.Erp.Domain.AggregateRoots.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FiscalCode")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("MMS.Erp.Domain.AggregateRoots.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<decimal>("DutyStamp")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("InvoiceDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<int>("VAT")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("MMS.Erp.Domain.Entities.ExpenseRecord", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal?>("Accommodation")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExpenseReportId")
                        .HasColumnType("int");

                    b.Property<decimal?>("KmReimbursement")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("LumpSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Meals")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PathToAttachment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Tolls")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("TraveledKm")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseReportId");

                    b.ToTable("ExpenseRecords");
                });

            modelBuilder.Entity("MMS.Erp.Domain.Entities.ExpenseReport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ExpenseReports");
                });

            modelBuilder.Entity("MMS.Erp.Domain.AggregateRoots.Invoice", b =>
                {
                    b.HasOne("MMS.Erp.Domain.AggregateRoots.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("MMS.Erp.Domain.Entities.ExpenseRecord", b =>
                {
                    b.HasOne("MMS.Erp.Domain.Entities.ExpenseReport", "ExpenseReport")
                        .WithMany("ExpenseRecords")
                        .HasForeignKey("ExpenseReportId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ExpenseReport");
                });

            modelBuilder.Entity("MMS.Erp.Domain.Entities.ExpenseReport", b =>
                {
                    b.HasOne("MMS.Erp.Domain.AggregateRoots.Employee", null)
                        .WithMany("ExpenseReports")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("MMS.Erp.Domain.AggregateRoots.Customer", b =>
                {
                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("MMS.Erp.Domain.AggregateRoots.Employee", b =>
                {
                    b.Navigation("ExpenseReports");
                });

            modelBuilder.Entity("MMS.Erp.Domain.Entities.ExpenseReport", b =>
                {
                    b.Navigation("ExpenseRecords");
                });
#pragma warning restore 612, 618
        }
    }
}
