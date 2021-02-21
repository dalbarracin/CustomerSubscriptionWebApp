using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerSubscriptionWebApp.Models
{
    public class SubscriptionViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Created { get; set; }

        [Required]
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }

        [Required]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }

        public SubscriptionViewModel()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }
    }
}
