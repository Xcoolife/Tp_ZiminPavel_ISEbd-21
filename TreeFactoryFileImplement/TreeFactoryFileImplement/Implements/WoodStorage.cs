using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeFactoryBusinessLogic.BindingModels;
using TreeFactoryBusinessLogic.Interfaces;
using TreeFactoryBusinessLogic.ViewModels;
using TreeFactoryFileImplement.Models;

namespace TreeFactoryFileImplement.Implements
{
    public class WoodStorage : IWoodStorage
    {
        private readonly FileDataListSingleton source;
        public WoodStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<WoodViewModel> GetFullList()
        {
            return source.Woods
            .Select(CreateModel)
           .ToList();
        }
        public List<WoodViewModel> GetFilteredList(WoodBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.Woods
            .Where(rec => rec.WoodName.Contains(model.WoodName))
            .Select(CreateModel)
            .ToList();
        }
        public WoodViewModel GetElement(WoodBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var wood = source.Woods
            .FirstOrDefault(rec => rec.WoodName == model.WoodName ||
           rec.Id == model.Id);
            return wood != null ? CreateModel(wood) : null;
        }
        public void Insert(WoodBindingModel model)
        {
            int maxId = source.Woods.Count > 0 ? source.Components.Max(rec => rec.Id): 0;
            var element = new Wood
            {
                Id = maxId + 1,
                WoodComponents = new Dictionary<int, int>()
            };
            source.Woods.Add(CreateModel(model, element));
        }
        public void Update(WoodBindingModel model)
        {
            var element = source.Woods.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(WoodBindingModel model)
        {
            Wood element = source.Woods.FirstOrDefault(rec => rec.Id ==
           model.Id);
            if (element != null)
            {
                source.Woods.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
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
            foreach (var component in model.WoodComponents)
            {
                if (wood.WoodComponents.ContainsKey(component.Key))
                {
                    wood.WoodComponents[component.Key] =
                   model.WoodComponents[component.Key].Item2;
                }
                else
                {
                    wood.WoodComponents.Add(component.Key,
                   model.WoodComponents[component.Key].Item2);
                }
            }
            return wood;
        }
        private WoodViewModel CreateModel(Wood wood)
        {
            return new WoodViewModel
            {
                Id = wood.Id,
                WoodName = wood.WoodName,
                Price = wood.Price,
                WoodComponents = wood.WoodComponents.ToDictionary(recPC => recPC.Key, recPC =>
                (source.Components.FirstOrDefault(recC => recC.Id ==
                recPC.Key)?.ComponentName, recPC.Value))
            };
        }
    }
}
