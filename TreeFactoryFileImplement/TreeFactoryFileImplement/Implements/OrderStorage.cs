﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeFactoryBusinessLogic.BindingModels;
using TreeFactoryBusinessLogic.Interfaces;
using TreeFactoryBusinessLogic.ViewModels;
using TreeFactoryFileImplement.Models;

namespace TreeFactoryFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly FileDataListSingleton source;
        public OrderStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<OrderViewModel> GetFullList()
        {
            return source.Orders
            .Select(CreateModel)
           .ToList();
        }
        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {

            if (model == null)
            {
                return null;
            }
            return source.Orders.Where(rec => rec.WoodId.ToString().Contains(model.WoodId.ToString())).Select(CreateModel).ToList();
        }
        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var order = source.Orders.FirstOrDefault(rec => rec.WoodId == model.WoodId || rec.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }
        public void Insert(OrderBindingModel model)
        {
            int maxId = source.Orders.Count > 0 ? source.Orders.Max(rec => rec.Id) : 0;

            var order = new Order { Id = maxId + 1 };
            source.Orders.Add(CreateModel(model, order));
        }

        public void Update(OrderBindingModel model)
        {
            var order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }

            CreateModel(model, order);
        }

        public void Delete(OrderBindingModel model)
        {
            Order order = source.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (order != null)
            {
                source.Orders.Remove(order);
            }
            else
            {
                throw new Exception("Заказ не найден");
            }
        }

        private Order CreateModel(OrderBindingModel model, Order component)
        {
            component.WoodId = model.WoodId;
            component.Count = model.Count;
            component.Sum = model.Sum;
            component.Status = model.Status;
            component.DateCreate = model.DateCreate;
            component.DateImplement = model.DateImplement;
            return component;
        }

        private OrderViewModel CreateModel(Order order)
        {

            Wood wood = source.Woods.FirstOrDefault(x => x.Id == order.WoodId);

            return new OrderViewModel
            {
                Id = order.Id,
                WoodId = order.WoodId,
                Count = order.Count,
                Sum = order.Sum,
                DateCreate = order.DateCreate,
                Status = order.Status,
                DateImplement = order.DateImplement,
                WoodName = wood.WoodName
            };
        }

    }
}
