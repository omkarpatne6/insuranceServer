using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Insurance_server.Models;

public partial class InsuranceDbContext : DbContext
{
    public InsuranceDbContext()
    {
    }

    public InsuranceDbContext(DbContextOptions<InsuranceDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }

    public virtual DbSet<PolicyDetail> PolicyDetails { get; set; }

    public virtual DbSet<UserLoginDetail> UserLoginDetails { get; set; }

   /* protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=OMKAR;Database=insurance_db;Integrated Security=True; TrustServerCertificate=True");
*/
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F52D882C8");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.Eid).HasColumnName("eid");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.EidNavigation).WithMany(p => p.EmployeeDetails)
                .HasForeignKey(d => d.Eid)
                .HasConstraintName("FK__EmployeeDet__eid__44FF419A");
        });

        modelBuilder.Entity<PaymentDetail>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__PaymentD__ED1FC9EA2C451028");

            entity.Property(e => e.PaymentId).HasColumnName("payment_id");
            entity.Property(e => e.CardNumber)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("card_number");
            entity.Property(e => e.CardOwnerName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("card_owner_name");
            entity.Property(e => e.Eid).HasColumnName("eid");
            entity.Property(e => e.SecurityCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("security_code");
            entity.Property(e => e.ValidThrough).HasColumnName("valid_through");

            entity.HasOne(d => d.EidNavigation).WithMany(p => p.PaymentDetails)
                .HasForeignKey(d => d.Eid)
                .HasConstraintName("FK__PaymentDeta__eid__4CA06362");
        });

        modelBuilder.Entity<PolicyDetail>(entity =>
        {
            entity.HasKey(e => e.PolicyId).HasName("PK__PolicyDe__47DA3F038278B8FB");

            entity.Property(e => e.PolicyId).HasColumnName("policy_id");
            entity.Property(e => e.CoverageDetails)
                .HasColumnType("text")
                .HasColumnName("coverage_details");
            entity.Property(e => e.Eid).HasColumnName("eid");
            entity.Property(e => e.PolicyName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("policy_name");
            entity.Property(e => e.PolicyType)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("policy_type");
            entity.Property(e => e.RemainingTenure).HasColumnName("remaining_tenure");

            entity.HasOne(d => d.EidNavigation).WithMany(p => p.PolicyDetails)
                .HasForeignKey(d => d.Eid)
                .HasConstraintName("FK__PolicyDetai__eid__4F7CD00D");
        });

        modelBuilder.Entity<UserLoginDetail>(entity =>
        {
            entity.HasKey(e => e.Eid).HasName("PK__UserLogi__D9509F6DD079AFD2");

            entity.Property(e => e.Eid)
                .ValueGeneratedNever()
                .HasColumnName("eid");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
