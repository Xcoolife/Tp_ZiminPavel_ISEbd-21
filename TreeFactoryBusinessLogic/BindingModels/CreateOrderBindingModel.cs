using System;
using System.Collections.Generic;
using System.Text;

namespace TreeFactoryBusinessLogic.BindingModels
{
    public class CreateOrderBindingModel
    {
        public int WoodId { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
    }
}
