using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TreeFactoryBusinessLogic.ViewModels
{
    public class WoodViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название Изделия")]
        public string WoodName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> WoodComponents { get; set; }
    }
}
