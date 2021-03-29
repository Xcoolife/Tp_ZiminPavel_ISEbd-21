using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TreeFactoryBusinessLogic.BindingModels;
using TreeFactoryBusinessLogic.Enums;
using TreeFactoryBusinessLogic.HelperModels;
using TreeFactoryBusinessLogic.Interfaces;
using TreeFactoryBusinessLogic.ViewModels;

namespace TreeFactoryBusinessLogic.BusinessLogics
{
    public class ReportLogic
    {
        private readonly IComponentStorage _componentStorage;
        private readonly IWoodStorage _woodStorage;
        private readonly IOrderStorage _orderStorage;

        public ReportLogic(IWoodStorage woodStorage, IComponentStorage componentStorage, IOrderStorage orderStorage)
        {
            _woodStorage = woodStorage;
            _componentStorage = componentStorage;
            _orderStorage = orderStorage;
        }

        public List<ReportWoodComponentViewModel> GetWoodComponents()
        {
            var components = _componentStorage.GetFullList();
            var woods = _woodStorage.GetFullList();
            var list = new List<ReportWoodComponentViewModel>();
            foreach (var wood in woods)
            {
                var record = new ReportWoodComponentViewModel
                {
                    WoodName = wood.WoodName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };

                foreach (var component in components)
                {
                    if (wood.WoodComponents.ContainsKey(component.Id))
                    {
                        record.Components.Add(new Tuple<string, int>(component.ComponentName, wood.WoodComponents[component.Id].Item2));
                        record.TotalCount += wood.WoodComponents[component.Id].Item2;
                    }
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel { DateFrom = model.DateFrom, DateTo = model.DateTo })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                WoodName = x.WoodName,
                Count = x.Count,
                Sum = x.Sum,
                Status = ((OrderStatus)Enum.Parse(typeof(OrderStatus), x.Status.ToString()))
            })
            .ToList();
        }

        public void SaveWoodsToWordFile(ReportBindingModel model)
        {
            SaveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Woods = _woodStorage.GetFullList()
            });
        }

        public void SaveWoodComponentToExcelFile(ReportBindingModel model)
        {
            SaveToExcel.CreateDoc(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                ComponentWoods = GetWoodComponents()
            });
        }

        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            SaveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

    }
}
