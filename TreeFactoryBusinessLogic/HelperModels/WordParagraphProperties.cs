using DocumentFormat.OpenXml.Math;
using System;
using System.Collections.Generic;
using System.Text;

namespace TreeFactoryBusinessLogic.HelperModels
{
    class WordParagraphProperties
    {
        public string Size { get; set; }
        public bool Bold { get; set; }
        public JustificationValues JustificationValues { get; set; }
    }
}
