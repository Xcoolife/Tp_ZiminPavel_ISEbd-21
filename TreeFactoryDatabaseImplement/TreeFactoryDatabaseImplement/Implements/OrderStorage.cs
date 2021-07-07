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
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new TreeFactoryDatabase())
            {
                return context.Orders.Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    WoodName = context.Woods.FirstOrDefault(r => r.Id == rec.WoodId).WoodName,
                    WoodId = rec.WoodId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                }).ToList();
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new TreeFactoryDatabase())
            {
                return context.Orders.Where(rec => rec.Id.Equals(model.Id)).Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    WoodName = context.Woods.FirstOrDefault(r => r.Id == rec.WoodId).WoodName,
                    WoodId = rec.WoodId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                }).ToList();
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new TreeFactoryDatabase())
            {
                var order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    WoodName = context.Woods.FirstOrDefault(r => r.Id == order.WoodId).WoodName,
                    WoodId = order.WoodId,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement
                } : null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new TreeFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Orders.Add(CreateModel(model, new Order(), context));
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

        public void Update(OrderBindingModel model)
        {
            using (var context = new TreeFactoryDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
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

        public void Delete(OrderBindingModel model)
        {
            using (var context = new TreeFactoryDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Orders.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order, TreeFactoryDatabase context)
        {
            order.WoodId = model.WoodId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
