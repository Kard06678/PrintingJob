using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrintingJob.Models
{
    public class JobStatusHistory
    {
        public int Id { get; set; }

        [ForeignKey(nameof(Job))]
        public int JobId { get; set; }
        public Job? Job { get; set; }

        public string Status { get; set; } = null!; // same values as CurrentStatus
        public string? Note { get; set; }
        public DateTime ChangedAt { get; set; }
    }
}