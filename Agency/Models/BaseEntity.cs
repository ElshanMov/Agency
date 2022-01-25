using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
    }
}
