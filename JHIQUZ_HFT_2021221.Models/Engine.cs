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
    [Table("engines")]
    public class Engine 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Required]
        public int Ccm { get; set; }
        //
        public FuelType Fuel { get; set; }
        //
        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Car> Cars { get; set; }
        [NotMapped]
        private static int IdCount = 0;
        public Engine()
        {
            Cars = new HashSet<Car>();
            Id = ++IdCount;
        }


    }

    public enum FuelType
    {
        Gasoline, Diesel, Hybrid
    }
}
