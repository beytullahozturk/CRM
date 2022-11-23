using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class TaskDto : IDto
    {
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
