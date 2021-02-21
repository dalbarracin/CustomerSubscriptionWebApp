using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerSubscriptionWebApp.Models
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Allowed a maximum of 20 characters")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Allowed a maximum of 50 characters")]
        public string Address { get; set; }
    }
}
