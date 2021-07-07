using System;
using System.Collections.Generic;
using System.Text;

namespace TreeFactoryBusinessLogic.BindingModels
{
    public class WoodBindingModel
    {
        public int? Id { get; set; }
        public string WoodName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> WoodComponents { get; set; }
    }
}