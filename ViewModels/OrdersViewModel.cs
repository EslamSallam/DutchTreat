using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DutchTreat.ViewModels
{
    public class OrdersViewModel
    {
        public int orderId { set; get; }
        public DateTime orderDate { set; get; }
        [Required]
        [MinLength(4)]
        public string orderNumber { set; get; }

        public ICollection<OrderItemsViewModel> Items { get; set; }
    }
}
