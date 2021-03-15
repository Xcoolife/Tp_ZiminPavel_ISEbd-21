using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TreeFactoryDatabaseImplement.Models
{
    public class Wood
    {
        public int Id { get; set; }

        [Required]
        public string WoodName { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("CannedId")]
        public virtual List<WoodComponent> WoodComponents { get; set; }

        [ForeignKey("CannedId")]
        public virtual List<Order> Order { get; set; }
    }
}
