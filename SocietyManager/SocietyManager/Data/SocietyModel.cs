namespace SocietyManager.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SocietyModel : DbContext
    {
        public SocietyModel()
            : base("name=SocietyModel")
        {
        }

        public virtual DbSet<Flat> Flats { get; set; }
        public virtual DbSet<Maintenance> Maintenances { get; set; }
        public virtual DbSet<Owner> Owners { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Receipt> Receipts { get; set; }
        public virtual DbSet<Society> Societies { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tenant> Tenants { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flat>()
                .HasMany(e => e.Maintenances)
                .WithRequired(e => e.Flat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flat>()
                .HasMany(e => e.Owners)
                .WithRequired(e => e.Flat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Flat>()
                .HasMany(e => e.Tenants)
                .WithRequired(e => e.Flat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maintenance>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Maintenance>()
                .Property(e => e.Received)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Maintenance>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Maintenance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Maintenance>()
                .HasMany(e => e.Receipts)
                .WithRequired(e => e.Maintenance)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Owner>()
                .HasMany(e => e.Payments)
                .WithRequired(e => e.Owner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Owner>()
                .HasMany(e => e.Tenants)
                .WithRequired(e => e.Owner)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Payment>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Payment>()
                .Property(e => e.PmntMadeBy)
                .IsFixedLength();

            modelBuilder.Entity<Payment>()
                .HasMany(e => e.Receipts)
                .WithRequired(e => e.Payment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Tenants)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Receipt>()
                .Property(e => e.Received)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Society>()
                .HasMany(e => e.Owners)
                .WithRequired(e => e.Society)
                .WillCascadeOnDelete(false);
        }
    }
}
