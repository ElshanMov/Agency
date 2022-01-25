using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Agency.Models
{
    public class Portfolio:BaseEntity
    {
        [Required]
        [StringLength(maximumLength:(20))]
        public string Title { get; set; }
        [Required]
        [StringLength(maximumLength: (80))]
        public string SubTitle { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Required]
        [StringLength(maximumLength: (20))]
        public string ImageTitle { get; set; }
        [Required]
        [StringLength(maximumLength: (20))]
        public string ImageDesc { get; set; }
        [Required]
        [StringLength(maximumLength: (20))]
        public string PorfolioName { get; set; }
        [Required]
        [StringLength(maximumLength: (80))]
        public string PortfolioSubTitle { get; set; }
        [Required]
        [StringLength(maximumLength: (300))]

        public string PortfolioDesc { get; set; }
        [Required]
        [StringLength(maximumLength: (20))]

        public string Client { get; set; }
        [Required]
        [StringLength(maximumLength: (20))]
        public string Category { get; set; }
        [Required]
        [StringLength(maximumLength: (30))]
        public string BtnText { get; set; }


    }
}
