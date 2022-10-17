using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FirstBlazorWeb.Models
{
    public partial class EXLogContext : DbContext
    {
        public EXLogContext()
        {
        }

        public EXLogContext(DbContextOptions<EXLogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Board> Boards { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Exercise> Exercises { get; set; } = null!;
        public virtual DbSet<Exerciselog> Exerciselogs { get; set; } = null!;
        public virtual DbSet<Healthchart> Healthcharts { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-0H6UIFL\\SQLEXPRESS;Initial Catalog=EXLog;Persist Security Info=True;User ID=sa;Password=dlqlthvmxm1!");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>(entity =>
            {
                entity.HasKey(e => e.Bono)
                    .HasName("PK__BOARD__39B5C70271E27938");

                entity.ToTable("BOARD");

                entity.Property(e => e.Bono)
                    .ValueGeneratedNever()
                    .HasColumnName("BONO");

                entity.Property(e => e.Attachfile)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("ATTACHFILE");

                entity.Property(e => e.Boardtype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BOARDTYPE");

                entity.Property(e => e.Comment)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Content)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Image)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Readhit).HasColumnName("READHIT");

                entity.Property(e => e.Recommend).HasColumnName("RECOMMEND");

                entity.Property(e => e.Regdate)
                    .HasColumnType("date")
                    .HasColumnName("REGDATE");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Boards)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BOARD__ID__38996AB5");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.HasKey(e => e.Cono)
                    .HasName("PK__COMMENT__AA1D11AE0551435A");

                entity.ToTable("COMMENT");

                entity.Property(e => e.Cono)
                    .ValueGeneratedNever()
                    .HasColumnName("CONO");

                entity.Property(e => e.Bono).HasColumnName("bono");

                entity.Property(e => e.Comment1)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("COMMENT");

                entity.Property(e => e.Depthno).HasColumnName("DEPTHNO");

                entity.Property(e => e.Groupno).HasColumnName("GROUPNO");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Recommend).HasColumnName("RECOMMEND");

                entity.Property(e => e.Regdate)
                    .HasColumnType("date")
                    .HasColumnName("REGDATE");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.HasOne(d => d.BonoNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Bono)
                    .HasConstraintName("FK__COMMENT__bono__4222D4EF");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMMENT__ID__3B75D760");
            });

            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.HasKey(e => e.Exname)
                    .HasName("PK__EXERCISE__4D6E5269DF949AFD");

                entity.ToTable("EXERCISE");

                entity.Property(e => e.Exname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXNAME");

                entity.Property(e => e.Equipment)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EQUIPMENT");

                entity.Property(e => e.Extype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXTYPE");
            });

            modelBuilder.Entity<Exerciselog>(entity =>
            {
                entity.HasKey(e => e.Exno)
                    .HasName("PK__EXERCISE__DE75469D3E5EDD2D");

                entity.ToTable("EXERCISELOG");

                entity.Property(e => e.Exno)
                    .ValueGeneratedNever()
                    .HasColumnName("EXNO");

                entity.Property(e => e.Exdate)
                    .HasColumnType("date")
                    .HasColumnName("EXDATE");

                entity.Property(e => e.Eximage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXIMAGE");

                entity.Property(e => e.Exinten)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXINTEN");

                entity.Property(e => e.Exlog)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXLOG");

                entity.Property(e => e.Exname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXNAME");

                entity.Property(e => e.Experiod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EXPERIOD");

                entity.Property(e => e.Exrep)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXREP");

                entity.Property(e => e.Exset)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("EXSET");

                entity.Property(e => e.Extime).HasColumnName("EXTIME");

                entity.Property(e => e.Extype)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EXTYPE");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Memo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MEMO");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Exerciselogs)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EXERCISELOG__ID__3E52440B");
            });

            modelBuilder.Entity<Healthchart>(entity =>
            {
                entity.HasKey(e => e.Heno)
                    .HasName("PK__HEALTHCH__01645DB135C5DA21");

                entity.ToTable("HEALTHCHART");

                entity.Property(e => e.Heno)
                    .ValueGeneratedNever()
                    .HasColumnName("HENO");

                entity.Property(e => e.Bun).HasColumnName("BUN");

                entity.Property(e => e.Crtn).HasColumnName("CRTN");

                entity.Property(e => e.Fat).HasColumnName("FAT");

                entity.Property(e => e.Glufa).HasColumnName("GLUFA");

                entity.Property(e => e.Gluhemo).HasColumnName("GLUHEMO");

                entity.Property(e => e.Hdl).HasColumnName("HDL");

                entity.Property(e => e.Height).HasColumnName("HEIGHT");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Jobtype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JOBTYPE");

                entity.Property(e => e.Ldl).HasColumnName("LDL");

                entity.Property(e => e.Memo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MEMO");

                entity.Property(e => e.Muscle).HasColumnName("MUSCLE");

                entity.Property(e => e.Regdate)
                    .HasColumnType("date")
                    .HasColumnName("REGDATE");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Totalcho).HasColumnName("TOTALCHO");

                entity.Property(e => e.Weight).HasColumnName("WEIGHT");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.Healthcharts)
                    .HasForeignKey(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HEALTHCHART__ID__412EB0B6");
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("MEMBER");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ID");

                entity.Property(e => e.Age).HasColumnName("AGE");

                entity.Property(e => e.Email)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Exhistory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("exhistory");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GENDER");

                entity.Property(e => e.Hp).HasColumnName("HP");

                entity.Property(e => e.Mehistory)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("mehistory");

                entity.Property(e => e.Memo)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MEMO");

                entity.Property(e => e.Name)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Nick)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("NICK");

                entity.Property(e => e.Pimage)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("PIMAGE");

                entity.Property(e => e.Postop)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("postop");

                entity.Property(e => e.Pw)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PW");

                entity.Property(e => e.Confirmpw)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONFIRMPW");

                entity.Property(e => e.Remark)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("REMARK");

                entity.Property(e => e.Resposibility)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("RESPOSIBILITY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
