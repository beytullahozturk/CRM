using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Category : IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Decription { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
