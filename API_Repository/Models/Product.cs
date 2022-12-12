using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Repository.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public int ProductNumber { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Property { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;


    }
}
