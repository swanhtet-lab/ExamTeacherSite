using System;
using System.Collections.Generic;
using ExamProject.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamProject.Data;

public partial class ExamProjectContext : DbContext
{
    public ExamProjectContext()
    {
    }

    public ExamProjectContext(DbContextOptions<ExamProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<QuestionMode> QuestionModes { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentAnswer> StudentAnswers { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeachertQa> TeachertQas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-7R5BI2H\\INSTANCE2022;Initial Catalog=ExamProject;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Class>(entity =>
        {
            entity.ToTable("Class");

            entity.Property(e => e.Class1)
                .IsUnicode(false)
                .HasColumnName("Class");

            entity.HasOne(d => d.Department).WithMany(p => p.Classes)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Class_Department");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.ToTable("Department");

            entity.Property(e => e.Department1)
                .IsUnicode(false)
                .HasColumnName("Department");
        });

        modelBuilder.Entity<QuestionMode>(entity =>
        {
            entity.ToTable("QuestionMode");

            entity.Property(e => e.GivenPoint)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.QuestionMode1)
                .IsUnicode(false)
                .HasColumnName("QuestionMode");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.ToTable("Student");

            entity.Property(e => e.StudentName).IsUnicode(false);

            entity.HasOne(d => d.Class).WithMany(p => p.Students)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_Student_Class");
        });

        modelBuilder.Entity<StudentAnswer>(entity =>
        {
            entity.ToTable("StudentAnswer");

            entity.Property(e => e.StudentAnswer1).HasColumnName("StudentAnswer");

            entity.HasOne(d => d.QuestionMode).WithMany(p => p.StudentAnswers)
                .HasForeignKey(d => d.QuestionModeId)
                .HasConstraintName("FK_StudentAnswer_QuestionMode");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentAnswers)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK_StudentAnswer_Student");

            entity.HasOne(d => d.TeacherQuestionAnswer).WithMany(p => p.StudentAnswers)
                .HasForeignKey(d => d.TeacherQuestionAnswerId)
                .HasConstraintName("FK_StudentAnswer_TeachertQA");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.ToTable("Subject");

            entity.Property(e => e.AvailableTime)
                .IsRowVersion()
                .IsConcurrencyToken();
            entity.Property(e => e.Status).IsUnicode(false);
            entity.Property(e => e.Subject1)
                .IsUnicode(false)
                .HasColumnName("Subject");

            entity.HasOne(d => d.Class).WithMany(p => p.Subjects)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK_Subject_Class");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.ToTable("Teacher");

            entity.Property(e => e.Position).IsUnicode(false);
            entity.Property(e => e.TeacherName).IsUnicode(false);

            entity.HasOne(d => d.Department).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK_Teacher_Department");
        });

        modelBuilder.Entity<TeachertQa>(entity =>
        {
            entity.HasKey(e => e.TeacherQuestionAnswerId);

            entity.ToTable("TeachertQA");

            entity.HasOne(d => d.QuestionMode).WithMany(p => p.TeachertQas)
                .HasForeignKey(d => d.QuestionModeId)
                .HasConstraintName("FK_TeachertQA_QuestionMode");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeachertQas)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK_TeachertQA_Subject");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
