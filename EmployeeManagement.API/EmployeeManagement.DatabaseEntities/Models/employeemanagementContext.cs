﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeManagement.DatabaseEntities.Models
{
    public partial class employeemanagementContext : DbContext
    {
        public employeemanagementContext()
        {
        }

        public employeemanagementContext(DbContextOptions<employeemanagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;
        public virtual DbSet<State> States { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;database=employeemanagement;user=test;password=test", Microsoft.EntityFrameworkCore.ServerVersion.Parse("5.7.39-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("latin1_swedish_ci")
                .HasCharSet("latin1");

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.HasIndex(e => e.MemberId, "FK_Employee_Member_idx");

                entity.HasIndex(e => e.StateId, "FK_Employee_State_idx");

                entity.Property(e => e.DateOfJoin).HasColumnType("datetime");

                entity.Property(e => e.Designation).HasMaxLength(250);

                entity.Property(e => e.Salary).HasPrecision(10);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Employee_Member");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Employee_State");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                entity.Property(e => e.DateOfBirth).HasColumnType("datetime");

                entity.Property(e => e.Gender).HasMaxLength(10);

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("state");

                entity.Property(e => e.StateCode).HasMaxLength(10);

                entity.Property(e => e.StateName).HasMaxLength(250);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
