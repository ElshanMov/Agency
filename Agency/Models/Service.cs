using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Models
{
    public class Service:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:(20))]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: (80))]
        public string SubTitle { get; set; }
        [Required]        
        public string Icon { get; set; }
        [Required]
        [StringLength(maximumLength: (20))]
        public string ServiceName { get; set; }
        [Required]
        [StringLength(maximumLength: (300))]
        public string ServiceDesc { get; set; }
    }
}
