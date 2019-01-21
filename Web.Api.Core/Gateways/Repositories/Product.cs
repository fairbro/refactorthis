using System;

namespace Web.Api.Core.Gateways.Repositories
{
    public class Product
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public decimal DeliveryPrice { get; set; }
    }
}