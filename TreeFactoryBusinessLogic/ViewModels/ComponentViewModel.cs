using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TreeFactoryBusinessLogic.ViewModels
{
    public class ComponentViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}
