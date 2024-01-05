using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Project2PHE.Models;

namespace Project2PHE.Contexts
{
    public class RegisterDbContext : DbContext
    {
        public RegisterDbContext() : base("name=RegisterDbContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Account> Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.Guid);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Guid)
                .HasMaxLength(36);

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .HasMaxLength(50);

            modelBuilder.Entity<Employee>()
                .Property(e => e.CreateDate);

            modelBuilder.Entity<Employee>()
                .Property(e => e.IsDeleted);

            modelBuilder.Entity<Employee>()
                .HasRequired(e => e.AccountNavigation)
                .WithRequiredDependent();

            modelBuilder.Entity<Vendor>()
                .HasKey(e => e.Guid);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Guid)
                .HasMaxLength(36);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.CompanyName)
                .HasMaxLength(50);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Address)
                .HasMaxLength(255);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.CompanyEmail)
                .HasMaxLength(50);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Phone)
                .HasMaxLength(15);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.Photo);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.IsApproved);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.ApprovedBy)
                .HasMaxLength(36);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.CreateDate);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.IsDeleted);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.BusinessField)
                .HasMaxLength(255);

            modelBuilder.Entity<Vendor>()
                .Property(e => e.BusinessType)
                .HasMaxLength(255);

            modelBuilder.Entity<Vendor>()
                .HasRequired(e => e.EmployeeNavigation)
                .WithMany(p => p.Vendors)
                .HasForeignKey(d => d.ApprovedBy);

            modelBuilder.Entity<Vendor>()
                .HasRequired(e => e.AccountNavigation)
                .WithRequiredDependent();

            modelBuilder.Entity<Account>()
                .HasKey(e => e.Guid);

            modelBuilder.Entity<Account>()
                .Property(e => e.Guid)
                .HasMaxLength(36);

            modelBuilder.Entity<Account>()
                .Property(e => e.Role)
                .HasMaxLength(50);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .HasMaxLength(20);
        }
    }
}