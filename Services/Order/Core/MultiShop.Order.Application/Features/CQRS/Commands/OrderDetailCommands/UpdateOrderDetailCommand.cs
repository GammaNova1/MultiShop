using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands
{
    public class UpdateOrderDetailCommand
    {
        public int OrderDetailId { get; set; }
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public Decimal ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public Decimal ProductTotalPrice { get; set; }
        public int OrderingId { get; set; }
    }
}
