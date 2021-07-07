using System;
using System.Collections.Generic;
using System.Text;

namespace TreeFactoryBusinessLogic.ViewModels
{
    public class ReportWoodComponentViewModel
    {
        public string ComponentName { get; set; }
        public string WoodName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components { get; set; }
    }
}
