using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace BusinessObjects.Models
{
    public partial class TarotBookingContext : DbContext
    {
        public TarotBookingContext()
        {
        }

        public TarotBookingContext(DbContextOptions<TarotBookingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bill> Bills { get; set; } = null!;
        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<SessionType> SessionTypes { get; set; } = null!;
        public virtual DbSet<TarotReader> TarotReaders { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetConnectionString());
            }
        }
        private string GetConnectionString()
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .Build();
            var strConn = config["ConnectionStrings:DefaultConnectionString"];
            return strConn;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>(entity =>
            {
                entity.Property(e => e.BillingDate).HasColumnType("datetime");

                entity.HasOne(d => d.Payment)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.PaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Bills__PaymentId__37A5467C");
            });

            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__Custome__38996AB5");

                entity.HasOne(d => d.Schedule)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.ScheduleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__Schedul__398D8EEE");

                entity.HasOne(d => d.TarotReader)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.TarotReaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__TarotRe__3A81B327");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Customer__UserId__3B75D760");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("Feedback");

                entity.Property(e => e.Comments).HasMaxLength(1000);

                entity.Property(e => e.Date).HasColumnType("date");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__Custom__3C69FB99");

                entity.HasOne(d => d.TarotReader)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.TarotReaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Feedback__TarotR__3D5E1FD2");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("Payment");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethod).HasMaxLength(255);

                entity.HasOne(d => d.Booking)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.BookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Payment__Booking__3E52440B");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.ToTable("Schedule");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__Custom__3F466844");

                entity.HasOne(d => d.TarotReader)
                    .WithMany(p => p.Schedules)
                    .HasForeignKey(d => d.TarotReaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Schedule__TarotR__403A8C7D");
            });

            modelBuilder.Entity<SessionType>(entity =>
            {
                entity.ToTable("SessionType");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<TarotReader>(entity =>
            {
                entity.ToTable("TarotReader");

                entity.Property(e => e.Description).HasMaxLength(4000);

                entity.Property(e => e.Introduction).HasMaxLength(500);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TarotReaders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TarotRead__UserI__412EB0B6");

                entity.HasMany(d => d.SessionTypes)
                    .WithMany(p => p.TarotReaders)
                    .UsingEntity<Dictionary<string, object>>(
                        "TarotReaderSessionType",
                        l => l.HasOne<SessionType>().WithMany().HasForeignKey("SessionTypeId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__TarotRead__Sessi__4222D4EF"),
                        r => r.HasOne<TarotReader>().WithMany().HasForeignKey("TarotReaderId").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__TarotRead__Tarot__4316F928"),
                        j =>
                        {
                            j.HasKey("TarotReaderId", "SessionTypeId").HasName("PK__TarotRea__AF7828A9A236C251");

                            j.ToTable("TarotReaderSessionType");
                        });
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Address).HasMaxLength(1000);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName).HasMaxLength(255);

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__User__RoleId__440B1D61");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
