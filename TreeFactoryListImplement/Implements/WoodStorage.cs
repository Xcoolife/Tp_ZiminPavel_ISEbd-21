using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeFactoryBusinessLogic.BindingModels;
using TreeFactoryBusinessLogic.Interfaces;
using TreeFactoryBusinessLogic.ViewModels;
using TreeFactoryListImplement.Models;

namespace TreeFactoryListImplement.Implements
{
    public class WoodStorage : IWoodStorage
    {
        private readonly DataListSingleton source;
        public WoodStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<WoodViewModel> GetFullList()
        {
            List<WoodViewModel> result = new List<WoodViewModel>();
            foreach (var wood in source.Woods)
            {
                result.Add(CreateModel(wood));
            }
            return result;
        }
        public List<WoodViewModel> GetFilteredList(WoodBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<WoodViewModel> result = new List<WoodViewModel>();
            foreach (var wood in source.Woods)
            {
                if (wood.WoodName.Contains(model.WoodName))
                {
                    result.Add(CreateModel(wood));
                }
            }
            return result;
        }
        public WoodViewModel GetElement(WoodBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var wood in source.Woods)
            {
                if (wood.Id == model.Id || wood.WoodName ==
                model.WoodName)
                {
                    return CreateModel(wood);
                }
            }
            return null;
        }
        public void Insert(WoodBindingModel model)
        {
            Wood tempWood = new Wood
            {
                Id = 1,
                WoodComponents = new Dictionary<int, int>()
            };
            foreach (var wood in source.Woods)
            {
                if (wood.Id >= tempWood.Id)
                {
                    tempWood.Id = wood.Id + 1;
                }
            }
            source.Woods.Add(CreateModel(model, tempWood));
        }
        public void Update(WoodBindingModel model)
        {
            Wood tempWood = null;
            foreach (var wood in source.Woods)
            {
                if (wood.Id == model.Id)
                {
                    tempWood = wood;
                }
            }
            if (tempWood == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempWood);
        }
        public void Delete(WoodBindingModel model)
        {
            for (int i = 0; i < source.Woods.Count; ++i)
            {
                if (source.Woods[i].Id == model.Id)
                {
                    source.Woods.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Wood CreateModel(WoodBindingModel model, Wood wood)
        {
            wood.WoodName = model.WoodName;
            wood.Price = model.Price;
            foreach (var key in wood.WoodComponents.Keys.ToList())
            {
                if (!model.WoodComponents.ContainsKey(key))
                {
                    wood.WoodComponents.Remove(key);
                }
            }
            foreach (var woods in model.WoodComponents)
            {
                if (wood.WoodComponents.ContainsKey(woods.Key))
                {
                    wood.WoodComponents[woods.Key] =
                    model.WoodComponents[woods.Key].Item2;
                }
                else
                {
                    wood.WoodComponents.Add(woods.Key,
                    model.WoodComponents[woods.Key].Item2);
                }
            }
            return wood;
        }
        private WoodViewModel CreateModel(Wood wood)
        {
            Dictionary<int, (string, int)> woodComponents = new
            Dictionary<int, (string, int)>();
            foreach (var sf in wood.WoodComponents)
            {
                string componentName = string.Empty;
                foreach (var woods in source.Components)
                {
                    if (sf.Key == wood.Id)
                    {
                        componentName = woods.ComponentName;
                        break;
                    }
                }
                woodComponents.Add(sf.Key, (componentName, sf.Value));
            }
            return new WoodViewModel
            {
                Id = wood.Id,
                WoodName = wood.WoodName,
                Price = wood.Price,
                WoodComponents = woodComponents
            };
        }
    }
}
