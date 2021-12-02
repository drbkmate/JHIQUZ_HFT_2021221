using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Models
{
    [Table("cars")]
    public class Car 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Model { get; set; }

        public int? BasePrice { get; set; } 

        [NotMapped] 
        public virtual Brand Brand { get; set; }

        public int BrandId { get; set; }

        [NotMapped]
        public virtual Engine Engine { get; set; }

        public int EngineId { get; set; }
        [NotMapped]
        private static int IdCount = 0;
        public Car()
        {
            Id = ++IdCount;
        }
    }
}
