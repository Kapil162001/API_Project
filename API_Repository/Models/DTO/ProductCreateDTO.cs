using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Repository.Models.DTO
{
    public class ProductCreateDTO
    {
        [Required]
        public int ProductNumber { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Property { get; set; } = string.Empty;
    }
}
