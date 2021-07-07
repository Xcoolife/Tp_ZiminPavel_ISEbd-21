using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TreeFactoryDatabaseImplement.Models
{
    public class WoodComponent
    {
        public int Id { get; set; }
        public int WoodId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual Wood Wood { get; set; }
    }
}
