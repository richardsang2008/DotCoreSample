using System;

namespace DataModels.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime OrderDate { get; set; }
    }
}