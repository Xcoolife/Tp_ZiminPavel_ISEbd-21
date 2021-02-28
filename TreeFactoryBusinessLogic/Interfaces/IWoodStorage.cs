using System;
using System.Collections.Generic;
using System.Text;
using TreeFactoryBusinessLogic.BindingModels;
using TreeFactoryBusinessLogic.ViewModels;

namespace TreeFactoryBusinessLogic.Interfaces
{
    public interface IWoodStorage
    {
        List<WoodViewModel> GetFullList();
        List<WoodViewModel> GetFilteredList(WoodBindingModel model);
        WoodViewModel GetElement(WoodBindingModel model);
        void Insert(WoodBindingModel model);
        void Update(WoodBindingModel model);
        void Delete(WoodBindingModel model);
    }
}
