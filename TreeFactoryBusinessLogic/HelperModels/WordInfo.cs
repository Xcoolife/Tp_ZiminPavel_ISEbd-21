using System;
using System.Collections.Generic;
using System.Text;
using TreeFactoryBusinessLogic.ViewModels;

namespace TreeFactoryBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<WoodViewModel> Woods { get; set; }
    }
}
