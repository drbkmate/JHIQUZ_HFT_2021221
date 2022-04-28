using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace JHIQUZ_HFT_2021221.Models
{
    [Table("brands")]
    public class Brand 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Car> Cars { get; set; }
        [NotMapped]
        private static int IdCount = 0;
        public Brand()
        {
            Cars = new HashSet<Car>();
            Id = ++IdCount;
        }
    }
}
