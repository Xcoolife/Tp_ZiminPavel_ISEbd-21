using System;
using System.Collections.Generic;
using TreeFactoryBusinessLogic.BindingModels;
using TreeFactoryBusinessLogic.Interfaces;
using TreeFactoryBusinessLogic.ViewModels;

namespace TreeFactoryBusinessLogic.BusinessLogics
{
    public class WoodLogic
    {
        private readonly IWoodStorage _woodStorage;
        public WoodLogic(IWoodStorage woodStorage)
        {
            _woodStorage = woodStorage;
        }
        public List<WoodViewModel> Read(WoodBindingModel model)
        {
            if (model == null)
            {
                return _woodStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<WoodViewModel> { _woodStorage.GetElement(model) };
            }
            return _woodStorage.GetFilteredList(model);
        }
        public void CreateOrUpdate(WoodBindingModel model)
        {
            var element = _woodStorage.GetElement(new WoodBindingModel
            {
                WoodName = model.WoodName
            });

            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Закуска с таким названием уже есть!");
            }
            if (model.Id.HasValue)
            {
                _woodStorage.Update(model);
            }
            else
            {
                _woodStorage.Insert(model);
            }
        }
        public void Delete(WoodBindingModel model)
        {
            var element = _woodStorage.GetElement(new WoodBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Закуска не найдена!");
            }
            _woodStorage.Delete(model);
        }
    }
}