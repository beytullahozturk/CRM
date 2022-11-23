using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class ProductDto : IDto
    {
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int? SupplierId { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitInStock { get; set; }
        public bool IsDelete { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
