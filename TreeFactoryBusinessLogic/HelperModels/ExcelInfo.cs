using System;
using System.Collections.Generic;
using System.Text;
using TreeFactoryBusinessLogic.ViewModels;

namespace TreeFactoryBusinessLogic.HelperModels
{
    class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportWoodComponentViewModel> ComponentWoods { get; set; }
    }
}
