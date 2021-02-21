using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CustomerSubscriptionWebApp.Models
{
    public class CustomerSubscriptionViewModel
    {

        public List<SelectListItem> Customers { get; set; }

        [Required(ErrorMessage = "The Customer field is required")]
        public string CustomerSelected { get; set; }

        public List<SelectListItem> Products { get; set; }

        [Required(ErrorMessage = "The Customer field is required")]
        public string ProductSelected { get; set; }

        public SubscriptionViewModel Subscription { get; set; }

    }
}
