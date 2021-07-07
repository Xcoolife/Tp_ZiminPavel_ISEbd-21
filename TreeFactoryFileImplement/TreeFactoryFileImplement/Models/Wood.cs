using System;
using System.Collections.Generic;
using System.Text;

namespace TreeFactoryFileImplement.Models
{
    public class Wood
    {
        public int Id { get; set; }
        public string WoodName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> WoodComponents { get; set; }
    }
}
