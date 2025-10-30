using System;
using Microsoft.EntityFrameworkCore;
using PrintingJob.Models;

namespace PrintingJob.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Job> Jobs { get; set; } = null!;
        public DbSet<JobStatusHistory> JobStatusHistories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // relationship
            modelBuilder.Entity<Job>()
                .HasMany(j => j.StatusHistory)
                .WithOne(h => h.Job)
                .HasForeignKey(h => h.JobId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed jobs (10 examples)
            //modelBuilder.Entity<Job>().HasData(
            //    new Job { Id = 1, ClientName = "ACME Corp", JobName = "Brochure Q1", Quantity = 500, Carrier = "USPS", CurrentStatus = "Received", CreatedAt = new DateTime(2025, 9, 1, 9, 0, 0), SLA_MailBy = new DateTime(2025, 9, 15, 17, 0, 0) },
            //    new Job { Id = 2, ClientName = "Beta LLC", JobName = "Sticker Run", Quantity = 2000, Carrier = "UPS", CurrentStatus = "Printing", CreatedAt = new DateTime(2025, 9, 2, 10, 30, 0), SLA_MailBy = new DateTime(2025, 9, 10, 17, 0, 0) },
            //    new Job { Id = 3, ClientName = "Gamma Inc", JobName = "Catalog 2025", Quantity = 1200, Carrier = "FedEx", CurrentStatus = "Inserting", CreatedAt = new DateTime(2025, 9, 3, 8, 15, 0), SLA_MailBy = new DateTime(2025, 9, 20, 17, 0, 0) },
            //    new Job { Id = 4, ClientName = "Delta Co", JobName = "Postcards", Quantity = 10000, Carrier = "USPS", CurrentStatus = "Mailed", CreatedAt = new DateTime(2025, 9, 4, 11, 45, 0), SLA_MailBy = new DateTime(2025, 9, 18, 17, 0, 0) },
            //    new Job { Id = 5, ClientName = "Epsilon", JobName = "Manuals", Quantity = 300, Carrier = "UPS", CurrentStatus = "Delivered", CreatedAt = new DateTime(2025, 9, 5, 14, 0, 0), SLA_MailBy = new DateTime(2025, 9, 25, 17, 0, 0) },
            //    new Job { Id = 6, ClientName = "Zeta Solutions", JobName = "Promo Cards", Quantity = 2500, Carrier = "FedEx", CurrentStatus = "Received", CreatedAt = new DateTime(2025, 9, 6, 9, 30, 0), SLA_MailBy = new DateTime(2025, 9, 22, 17, 0, 0) },
            //    new Job { Id = 7, ClientName = "Eta Partners", JobName = "Labels", Quantity = 8000, Carrier = "USPS", CurrentStatus = "Printing", CreatedAt = new DateTime(2025, 9, 7, 8, 45, 0), SLA_MailBy = new DateTime(2025, 9, 14, 17, 0, 0) },
            //    new Job { Id = 8, ClientName = "Theta Ltd", JobName = "Stickers Large", Quantity = 1500, Carrier = "UPS", CurrentStatus = "Exception", CreatedAt = new DateTime(2025, 9, 8, 13, 20, 0), SLA_MailBy = new DateTime(2025, 9, 30, 17, 0, 0) },
            //    new Job { Id = 9, ClientName = "Iota Group", JobName = "Invitation Set", Quantity = 600, Carrier = "FedEx", CurrentStatus = "Inserting", CreatedAt = new DateTime(2025, 9, 9, 10, 0, 0), SLA_MailBy = new DateTime(2025, 9, 19, 17, 0, 0) },
            //    new Job { Id = 10, ClientName = "Kappa Works", JobName = "Catalog Reprint", Quantity = 400, Carrier = "USPS", CurrentStatus = "Mailed", CreatedAt = new DateTime(2025, 9, 10, 15, 10, 0), SLA_MailBy = new DateTime(2025, 9, 28, 17, 0, 0) }
            //);

            //modelBuilder.Entity<JobStatusHistory>().HasData(
            //    new JobStatusHistory { Id = 1, JobId = 1, Status = "Received", Note = "Initial received", ChangedAt = new DateTime(2025, 9, 1, 9, 0, 0) },

            //    new JobStatusHistory { Id = 2, JobId = 2, Status = "Received", Note = "Initial received", ChangedAt = new DateTime(2025, 9, 2, 10, 30, 0) },
            //    new JobStatusHistory { Id = 3, JobId = 2, Status = "Printing", Note = "Started print run", ChangedAt = new DateTime(2025, 9, 2, 12, 0, 0) },

            //    new JobStatusHistory { Id = 4, JobId = 3, Status = "Received", Note = "Initial received", ChangedAt = new DateTime(2025, 9, 3, 8, 15, 0) },
            //    new JobStatusHistory { Id = 5, JobId = 3, Status = "Printing", Note = "Printed pages", ChangedAt = new DateTime(2025, 9, 4, 9, 0, 0) },
            //    new JobStatusHistory { Id = 6, JobId = 3, Status = "Inserting", Note = "Inserted into envelopes", ChangedAt = new DateTime(2025, 9, 5, 11, 0, 0) },

            //    new JobStatusHistory { Id = 7, JobId = 4, Status = "Received", Note = "Initial received", ChangedAt = new DateTime(2025, 9, 4, 11, 45, 0) },
            //    new JobStatusHistory { Id = 8, JobId = 4, Status = "Printing", Note = "Printed", ChangedAt = new DateTime(2025, 9, 5, 10, 0, 0) },
            //    new JobStatusHistory { Id = 9, JobId = 4, Status = "Inserting", Note = "Inserted", ChangedAt = new DateTime(2025, 9, 6, 9, 0, 0) },
            //    new JobStatusHistory { Id = 10, JobId = 4, Status = "Mailed", Note = "Shipped via USPS", ChangedAt = new DateTime(2025, 9, 7, 16, 0, 0) },

            //    new JobStatusHistory { Id = 11, JobId = 5, Status = "Received", Note = "Initial received", ChangedAt = new DateTime(2025, 9, 5, 14, 0, 0) },
            //    new JobStatusHistory { Id = 12, JobId = 5, Status = "Printing", Note = "Printed", ChangedAt = new DateTime(2025, 9, 6, 8, 0, 0) },
            //    new JobStatusHistory { Id = 13, JobId = 5, Status = "Mailed", Note = "Delivered", ChangedAt = new DateTime(2025, 9, 10, 12, 0, 0) }
            //);
        }
    }
}