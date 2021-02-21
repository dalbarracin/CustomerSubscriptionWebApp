using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerSubscriptionWebApp.Models
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(20, ErrorMessage = "Allowed a maximum of 20 characters")]
        public string Name { get; set; }
        
        [Required]
        [DataType(DataType.Currency)]
        [Range(1, int.MaxValue, ErrorMessage = "Only positive number allowed")]
        public decimal Price { get; set; }

        public ProductViewModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
