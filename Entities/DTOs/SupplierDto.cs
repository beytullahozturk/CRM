using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class SupplierDto : IDto
    {
        public string SupplierCompany { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsDelete { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
