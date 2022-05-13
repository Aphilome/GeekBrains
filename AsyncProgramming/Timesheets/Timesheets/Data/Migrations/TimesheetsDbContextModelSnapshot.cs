﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Timesheets.Data;

#nullable disable

namespace Timesheets.Data.Migrations
{
    [DbContext(typeof(TimesheetsDbContext))]
    partial class TimesheetsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.4");

            modelBuilder.Entity("Timesheets.Data.Entities.Client", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("InvoiceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Timesheets.Data.Entities.Contract", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<long?>("InvoiceId")
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("Number")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("SignDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("Timesheets.Data.Entities.Employee", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Grade")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Rate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Timesheets.Data.Entities.Invoice", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<ulong>("AccauntNumber")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ContractId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Sum")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("ContractId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Timesheets.Data.Entities.JobTask", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ContractId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<long?>("EmployeeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Pay")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("SpendTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ContractId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("JobTasks");
                });

            modelBuilder.Entity("Timesheets.Data.Entities.Client", b =>
                {
                    b.HasOne("Timesheets.Data.Entities.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Timesheets.Data.Entities.Contract", b =>
                {
                    b.HasOne("Timesheets.Data.Entities.Invoice", "Invoice")
                        .WithMany()
                        .HasForeignKey("InvoiceId");

                    b.Navigation("Invoice");
                });

            modelBuilder.Entity("Timesheets.Data.Entities.Invoice", b =>
                {
                    b.HasOne("Timesheets.Data.Entities.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("Timesheets.Data.Entities.Contract", "Contract")
                        .WithMany()
                        .HasForeignKey("ContractId");

                    b.Navigation("Client");

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("Timesheets.Data.Entities.JobTask", b =>
                {
                    b.HasOne("Timesheets.Data.Entities.Contract", "Contract")
                        .WithMany("Tasks")
                        .HasForeignKey("ContractId");

                    b.HasOne("Timesheets.Data.Entities.Employee", "Employee")
                        .WithMany("Tasks")
                        .HasForeignKey("EmployeeId");

                    b.Navigation("Contract");

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("Timesheets.Data.Entities.Contract", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Timesheets.Data.Entities.Employee", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
