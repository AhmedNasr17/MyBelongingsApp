using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyBelongingsApp.Models
{
    public partial class MyBelongingsAppDBContext : IdentityDbContext
    {
        public MyBelongingsAppDBContext()
        {
        }

        public MyBelongingsAppDBContext(DbContextOptions<MyBelongingsAppDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MyTasks> MyTasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=MyBelongingsAppDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MyTasks>(entity =>
            {
                entity.HasKey(e => e.MyTaskId);

                entity.Property(e => e.DeadLine).HasColumnType("datetime");

                entity.Property(e => e.MeantDay);

                entity.Property(e => e.StartTime).HasColumnType("datetime");

                entity.Property(e => e.Text).IsRequired();

                entity.Property(e => e.isDone)
                    .HasDefaultValueSql("('false')");
            });

            base.OnModelCreating(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
