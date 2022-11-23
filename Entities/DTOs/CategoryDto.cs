using Core.Entities;
using System;

namespace Entities.DTOs
{
    public class CategoryDto: IDto
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}

