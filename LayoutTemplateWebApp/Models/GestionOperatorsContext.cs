﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LayoutTemplateWebApp.Models;

public partial class GestionOperatorsContext : DbContext
{
    public GestionOperatorsContext(DbContextOptions<GestionOperatorsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdmOperator> AdmOperators { get; set; }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Equipment> Equipment { get; set; }

    public virtual DbSet<Facility> Facilities { get; set; }

    public virtual DbSet<Laboratory> Laboratories { get; set; }

    public virtual DbSet<Operator> Operators { get; set; }

    public virtual DbSet<SchedulexEquipment> SchedulexEquipments { get; set; }

    public virtual DbSet<SchedulexFacility> SchedulexFacilities { get; set; }

    public virtual DbSet<SchedulexOperator> SchedulexOperators { get; set; }
    public virtual DbSet<GetOperatorsForFacilityOnDateResult> GetOperatorsForFacilityOnDateResults { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdmOperator>(entity =>
        {
            entity.HasKey(e => e.idAdmOperator).HasName("PK__AdmOpera__DF5A81DCC16E96B0");

            entity.ToTable("AdmOperator");

            entity.Property(e => e.idAdmOperator).ValueGeneratedNever();
            entity.Property(e => e.cellphone).HasMaxLength(20);
            entity.Property(e => e.email).HasMaxLength(255);
        });

        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.HasKey(e => e.idClassroom).HasName("PK__Classroo__DF3B575D584FE290");

            entity.ToTable("Classroom");

            entity.Property(e => e.idClassroom)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.idFacilities)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.idFacilitiesNavigation).WithMany(p => p.Classrooms)
                .HasForeignKey(d => d.idFacilities)
                .HasConstraintName("FK__Classroom__idFac__34C8D9D1");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.idEquipment).HasName("PK__Equipmen__F5087F0298D242CC");

            entity.Property(e => e.idEquipment).ValueGeneratedNever();
            entity.Property(e => e.condition).HasMaxLength(255);
            entity.Property(e => e.name).HasMaxLength(255);
        });

        modelBuilder.Entity<Facility>(entity =>
        {
            entity.HasKey(e => e.idFacilities).HasName("PK__Facility__32C12FE6BA647021");

            entity.ToTable("Facility");

            entity.Property(e => e.idFacilities)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Laboratory>(entity =>
        {
            entity.HasKey(e => e.idLaboratory).HasName("PK__Laborato__CF6A6A1CFA2E3CF6");

            entity.ToTable("Laboratory");

            entity.Property(e => e.idLaboratory)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.idFacilities)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.idFacilitiesNavigation).WithMany(p => p.Laboratories)
                .HasForeignKey(d => d.idFacilities)
                .HasConstraintName("FK__Laborator__idFac__37A5467C");
        });

        modelBuilder.Entity<Operator>(entity =>
        {
            entity.HasKey(e => e.idOperator).HasName("PK__Operator__DDFD0965A0A7FDA1");

            entity.ToTable("Operator");

            entity.Property(e => e.idOperator).ValueGeneratedNever();
            entity.Property(e => e.cellphone).HasMaxLength(20);
            entity.Property(e => e.email).HasMaxLength(255);
        });

        modelBuilder.Entity<SchedulexEquipment>(entity =>
        {
            entity.HasKey(e => e.idSchedulexEquipment).HasName("PK__Schedule__C83BB4F0ED10A8EB");

            entity.ToTable("SchedulexEquipment");

            entity.Property(e => e.beginningHour).HasPrecision(0);
            entity.Property(e => e.finalDate).HasColumnType("date");
            entity.Property(e => e.finishingHour).HasPrecision(0);
            entity.Property(e => e.initialDate).HasColumnType("date");

            entity.HasOne(d => d.idEquipmentNavigation).WithMany(p => p.SchedulexEquipments)
                .HasForeignKey(d => d.idEquipment)
                .HasConstraintName("FK__Schedulex__idEqu__2D27B809");
        });

        modelBuilder.Entity<SchedulexFacility>(entity =>
        {
            entity.HasKey(e => e.idSchedulexFacility).HasName("PK__Schedule__5181FCD551A3B796");

            entity.ToTable("SchedulexFacility");

            entity.Property(e => e.activityDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.beginningHour).HasPrecision(0);
            entity.Property(e => e.date).HasColumnType("date");
            entity.Property(e => e.finishingHour).HasPrecision(0);
            entity.Property(e => e.idFacilities)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.idFacilitiesNavigation).WithMany(p => p.SchedulexFacilities)
                .HasForeignKey(d => d.idFacilities)
                .HasConstraintName("FK__Schedulex__idFac__31EC6D26");
        });

        modelBuilder.Entity<SchedulexOperator>(entity =>
        {
            entity.HasKey(e => e.idSchedulexOperator).HasName("PK__Schedule__21A3C99086E6F43C");

            entity.ToTable("SchedulexOperator");

            entity.Property(e => e.beginningHour).HasPrecision(0);
            entity.Property(e => e.day).HasColumnType("date");
            entity.Property(e => e.finishingHour).HasPrecision(0);
            entity.Property(e => e.idFacility)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.idFacilityNavigation).WithMany(p => p.SchedulexOperators)
                .HasForeignKey(d => d.idFacility)
                .HasConstraintName("FK__Schedulex__idFac__5441852A");

            entity.HasOne(d => d.idOperatorNavigation).WithMany(p => p.SchedulexOperators)
                .HasForeignKey(d => d.idOperator)
                .HasConstraintName("FK__Schedulex__idOpe__286302EC");
        });

        OnModelCreatingGeneratedProcedures(modelBuilder);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}