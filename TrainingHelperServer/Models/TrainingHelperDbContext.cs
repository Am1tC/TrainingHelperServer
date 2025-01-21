using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TrainingHelperServer.Models;

public partial class TrainingHelperDbContext : DbContext
{
    public TrainingHelperDbContext()
    {
    }

    public TrainingHelperDbContext(DbContextOptions<TrainingHelperDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Owner> Owners { get; set; }

    public virtual DbSet<Trainee> Trainees { get; set; }

    public virtual DbSet<TraineesInPractice> TraineesInPractices { get; set; }

    public virtual DbSet<Trainer> Trainers { get; set; }

    public virtual DbSet<Training> Training { get; set; }

    public virtual DbSet<TrainingField> TrainingFields { get; set; }

    public virtual DbSet<TrainingFieldsInTrainer> TrainingFieldsInTrainers { get; set; }

    public virtual DbSet<TrainingFieldsInTraining> TrainingFieldsInTrainings { get; set; }

    public virtual DbSet<TrainingPicture> TrainingPictures { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Initial Catalog=TrainingHelperDb;User ID=TrainingHelperLogin;Password=123;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Owner>(entity =>
        {
            entity.HasKey(e => e.OwnerId).HasName("PK__Owner__819385B8D1F9BBBC");
        });

        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.HasKey(e => e.TraineeId).HasName("PK__Trainee__3BA911CA52DF623B");
        });

        modelBuilder.Entity<TraineesInPractice>(entity =>
        {
            entity.HasKey(e => new { e.TraineeId, e.TrainingNumber }).HasName("PK__Trainees__2215D18D9D8A7564");

            entity.HasOne(d => d.Trainee).WithMany(p => p.TraineesInPractices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TraineesI__Train__30F848ED");

            entity.HasOne(d => d.TrainingNumberNavigation).WithMany(p => p.TraineesInPractices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TraineesI__Train__31EC6D26");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__Trainer__366A1A7C2699B6F2");
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.TrainingNumber).HasName("PK__Training__9BCC04702167C18E");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Training).HasConstraintName("FK__Training__Traine__2E1BDC42");
        });

        modelBuilder.Entity<TrainingField>(entity =>
        {
            entity.HasKey(e => e.TrainingFieldId).HasName("PK__Training__641895269C169D98");

            entity.Property(e => e.TrainingFieldId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TrainingFieldsInTrainer>(entity =>
        {
            entity.HasOne(d => d.Trainer).WithMany().HasConstraintName("FK__TrainingF__Train__37A5467C");

            entity.HasOne(d => d.TrainingField).WithMany().HasConstraintName("FK__TrainingF__Train__38996AB5");
        });

        modelBuilder.Entity<TrainingFieldsInTraining>(entity =>
        {
            entity.HasOne(d => d.TrainingField).WithMany().HasConstraintName("FK__TrainingF__Train__3A81B327");

            entity.HasOne(d => d.TrainingNumberNavigation).WithMany().HasConstraintName("FK__TrainingF__Train__3B75D760");
        });

        modelBuilder.Entity<TrainingPicture>(entity =>
        {
            entity.HasKey(e => e.PictureId).HasName("PK__Training__8C2866D8638669BE");

            entity.HasOne(d => d.TrainingNumberNavigation).WithMany(p => p.TrainingPictures).HasConstraintName("FK__TrainingP__Train__35BCFE0A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
