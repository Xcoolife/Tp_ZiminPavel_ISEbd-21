using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeFactoryBusinessLogic.BindingModels;
using TreeFactoryBusinessLogic.Interfaces;
using TreeFactoryBusinessLogic.ViewModels;
using TreeFactoryDatabaseImplement.Models;

namespace TreeFactoryDatabaseImplement.Implements
{
    public class WoodStorage : IWoodStorage
    {
        public List<WoodViewModel> GetFullList()
        {
            using (var context = new TreeFactoryDatabase())
            {
                return context.Woods.Include(rec => rec.WoodComponents).ThenInclude(rec => rec.Component).ToList().Select(rec => new WoodViewModel
                {
                    Id = rec.Id,
                    WoodName = rec.WoodName,
                    Price = rec.Price,
                    WoodComponents = rec.WoodComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                }).ToList();
            }
        }

        public List<WoodViewModel> GetFilteredList(WoodBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TreeFactoryDatabase())
            {
                return context.Woods.Include(rec => rec.WoodComponents).ThenInclude(rec => rec.Component).Where(rec => rec.WoodName.Contains(model.WoodName)).ToList().Select(rec => new WoodViewModel
                {
                    Id = rec.Id,
                    WoodName = rec.WoodName,
                    Price = rec.Price,
                }).ToList();
            }
        }

        public WoodViewModel GetElement(WoodBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new TreeFactoryDatabase())
            {
                var wood = context.Woods.Include(rec => rec.WoodComponents).ThenInclude(rec => rec.Component)
.FirstOrDefault(rec => rec.WoodName == model.WoodName || rec.Id == model.Id);
                return wood != null ?
                new WoodViewModel
                {
                    Id = wood.Id,
                    WoodName = wood.WoodName,
                    Price = wood.Price,
                    WoodComponents = wood.WoodComponents.ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
                } : null;
            }
        }

        public void Insert(WoodBindingModel model)
        {
            using (var context = new TreeFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        Wood wood = CreateModel(model, new Wood());
                        context.Woods.Add(wood);
                        context.SaveChanges();
                        CreateModel(model, wood, context);
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(WoodBindingModel model)
        {
            using (var context = new TreeFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Woods.FirstOrDefault(rec => rec.Id == model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(WoodBindingModel model)
        {
            using (var context = new TreeFactoryDatabase())
            {
                Wood element = context.Woods.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Woods.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Wood CreateModel(WoodBindingModel model, Wood wood)
        {
            wood.WoodName = model.WoodName;
            wood.Price = model.Price;
            return wood;
        }

        private Wood CreateModel(WoodBindingModel model, Wood wood, TreeFactoryDatabase context)
        {
            wood.WoodName = model.WoodName;
            wood.Price = model.Price;
            if (model.Id.HasValue)
            {
                var productComponents = context.WoodComponents.Where(rec => rec.WoodId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.WoodComponents.RemoveRange(productComponents.Where(rec => !model.WoodComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in productComponents)
                {
                    updateComponent.Count = model.WoodComponents[updateComponent.ComponentId].Item2;
                    model.WoodComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.WoodComponents)
            {
                context.WoodComponents.Add(new WoodComponent
                {
                    WoodId = wood.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return wood;
        }
    }
}
