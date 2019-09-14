using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CMTask.Models
{
    public class Product
    {
        [Key]
        public Guid id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string name { get; set; }
        [Required]
        public decimal? price { get; set; }
    }
}
