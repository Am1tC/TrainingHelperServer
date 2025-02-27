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
            entity.HasKey(e => e.OwnerId).HasName("PK__Owner__819385B847665012");
        });

        modelBuilder.Entity<Trainee>(entity =>
        {
            entity.HasKey(e => e.TraineeId).HasName("PK__Trainee__3BA911CA24821844");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<TraineesInPractice>(entity =>
        {
            entity.HasKey(e => new { e.TraineeId, e.TrainingNumber }).HasName("PK__Trainees__2215D18D5DB338BD");

            entity.HasOne(d => d.Trainee).WithMany(p => p.TraineesInPractices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TraineesI__Train__32E0915F");

            entity.HasOne(d => d.TrainingNumberNavigation).WithMany(p => p.TraineesInPractices)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TraineesI__Train__33D4B598");
        });

        modelBuilder.Entity<Trainer>(entity =>
        {
            entity.HasKey(e => e.TrainerId).HasName("PK__Trainer__366A1A7CE9DED212");

            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Training>(entity =>
        {
            entity.HasKey(e => e.TrainingNumber).HasName("PK__Training__9BCC0470AEC788DD");

            entity.HasOne(d => d.Trainer).WithMany(p => p.Training).HasConstraintName("FK__Training__Traine__300424B4");
        });

        modelBuilder.Entity<TrainingField>(entity =>
        {
            entity.HasKey(e => e.TrainingFieldId).HasName("PK__Training__64189526A31CB8F2");

            entity.Property(e => e.TrainingFieldId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TrainingFieldsInTrainer>(entity =>
        {
            entity.HasOne(d => d.Trainer).WithMany().HasConstraintName("FK__TrainingF__Train__398D8EEE");

            entity.HasOne(d => d.TrainingField).WithMany().HasConstraintName("FK__TrainingF__Train__3A81B327");
        });

        modelBuilder.Entity<TrainingFieldsInTraining>(entity =>
        {
            entity.HasOne(d => d.TrainingField).WithMany().HasConstraintName("FK__TrainingF__Train__3C69FB99");

            entity.HasOne(d => d.TrainingNumberNavigation).WithMany().HasConstraintName("FK__TrainingF__Train__3D5E1FD2");
        });

        modelBuilder.Entity<TrainingPicture>(entity =>
        {
            entity.HasKey(e => e.PictureId).HasName("PK__Training__8C2866D8DECC563E");

            entity.HasOne(d => d.TrainingNumberNavigation).WithMany(p => p.TrainingPictures).HasConstraintName("FK__TrainingP__Train__37A5467C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
