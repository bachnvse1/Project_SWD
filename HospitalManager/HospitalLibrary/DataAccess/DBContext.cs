using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HospitalLibrary.DataAccess;

public partial class DBContext : DbContext
{
    public DBContext()
    {
    }

    public DBContext(DbContextOptions<DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<HospitalService> HospitalServices { get; set; }

    public virtual DbSet<MedicalRecord> MedicalRecords { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<TreatmentPlan> TreatmentPlans { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BED9EB6F7D2");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).ValueGeneratedNever();
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<HospitalService>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Hospital__C51BB0EAB5F90D40");

            entity.ToTable("HospitalService");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.ServiceName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
        });

        modelBuilder.Entity<MedicalRecord>(entity =>
        {
            entity.HasKey(e => e.MedicalRecordId).HasName("PK__MedicalR__4411BA22F368D2B1");

            entity.ToTable("MedicalRecord");

            entity.Property(e => e.MedicalRecordId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasColumnType("text");
            entity.Property(e => e.UpdateAt).HasColumnType("datetime");

            entity.HasOne(d => d.Patient).WithMany(p => p.MedicalRecords)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__MedicalRe__Patie__35BCFE0A");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patient__970EC36611EBB985");

            entity.ToTable("Patient");

            entity.Property(e => e.PatientId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.Gender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.HealthCondition)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.HealthInsurance)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PatientName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");

            entity.HasOne(d => d.Room).WithMany(p => p.Patients)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__Patient__RoomId__2E1BDC42");

            entity.HasMany(d => d.Services).WithMany(p => p.Patients)
                .UsingEntity<Dictionary<string, object>>(
                    "PatientService",
                    r => r.HasOne<HospitalService>().WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PatientSe__Servi__4222D4EF"),
                    l => l.HasOne<Patient>().WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__PatientSe__Patie__412EB0B6"),
                    j =>
                    {
                        j.HasKey("PatientId", "ServiceId").HasName("PK__PatientS__2B5F784882DF74FE");
                        j.ToTable("PatientService");
                        j.IndexerProperty<int>("PatientId").HasColumnName("PatientID");
                        j.IndexerProperty<int>("ServiceId").HasColumnName("ServiceID");
                    });
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payment__9B556A38C944948C");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.TransactionTime).HasColumnType("datetime");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");

            entity.HasOne(d => d.Patient).WithMany(p => p.Payments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Payment__Patient__32E0915F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1AB32DA29F");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__Room__19EF6E6BC6CEBF27");

            entity.ToTable("Room");

            entity.Property(e => e.RoomId)
                .ValueGeneratedNever()
                .HasColumnName("Room_id");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.IsAvailable).HasColumnName("Is_available");
            entity.Property(e => e.RoomName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
        });

        modelBuilder.Entity<TreatmentPlan>(entity =>
        {
            entity.HasKey(e => new { e.PatientId, e.MedicineSection, e.TreatmentTime }).HasName("PK__Treatmen__7467D4795C38C4B1");

            entity.ToTable("TreatmentPlan");

            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.MedicineSection)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.TreatmentTime).HasColumnType("datetime");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.DoctorInCharge)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.TreatmentMethodSection)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Patient).WithMany(p => p.TreatmentPlans)
                .HasForeignKey(d => d.PatientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Treatment__Patie__3C69FB99");

            entity.HasOne(d => d.Service).WithMany(p => p.TreatmentPlans)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK__Treatment__Servi__3E52440B");

            entity.HasOne(d => d.User).WithMany(p => p.TreatmentPlans)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Treatment__UserI__3D5E1FD2");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C2AD20BBC");

            entity.ToTable("User");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__User__Department__286302EC");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleId__29572725");
        });

        modelBuilder.Entity<WorkSchedule>(entity =>
        {
            entity.HasKey(e => e.ScheduleId).HasName("PK__WorkSche__9C8A5B49C1377408");

            entity.ToTable("WorkSchedule");

            entity.Property(e => e.ScheduleId).ValueGeneratedNever();
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.PatientId).HasColumnName("PatientID");
            entity.Property(e => e.TimeSlot).HasColumnType("datetime");
            entity.Property(e => e.UpdateAt)
                .HasColumnType("datetime")
                .HasColumnName("update_at");
            entity.Property(e => e.UpdateBy).HasColumnName("update_by");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Patient).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__WorkSched__Patie__38996AB5");

            entity.HasOne(d => d.User).WithMany(p => p.WorkSchedules)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__WorkSched__UserI__398D8EEE");
        });

        modelBuilder.Entity<Patient>()
        .HasMany(p => p.Services)
        .WithMany(s => s.Patients)
        .UsingEntity<Dictionary<string, object>>("PatientService");


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
