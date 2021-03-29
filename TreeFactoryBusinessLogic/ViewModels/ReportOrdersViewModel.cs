using System;
using System.Collections.Generic;
using System.Text;
using TreeFactoryBusinessLogic.Enums;

namespace TreeFactoryBusinessLogic.ViewModels
{
    public class ReportOrdersViewModel
    {
        public DateTime DateCreate { get; set; }
        public string WoodName { get; set; }
        public int Count { get; set; }
        public decimal Sum { get; set; }
        public OrderStatus Status { get; set; }
    }
}
