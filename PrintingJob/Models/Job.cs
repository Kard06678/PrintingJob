using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PrintingJob.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        public string ClientName { get; set; } = null!;

        [Required]
        public string JobName { get; set; } = null!;

        public int Quantity { get; set; }

        [Required]
        public string Carrier { get; set; } = null!; // "USPS", "UPS", "FedEx"

        public string CurrentStatus { get; set; } = null!; // e.g. "Received", "Printing", ...

        public DateTime CreatedAt { get; set; }

        public DateTime SLA_MailBy { get; set; }

        // navigation
        public List<JobStatusHistory> StatusHistory { get; set; } = new List<JobStatusHistory>();
    }
}