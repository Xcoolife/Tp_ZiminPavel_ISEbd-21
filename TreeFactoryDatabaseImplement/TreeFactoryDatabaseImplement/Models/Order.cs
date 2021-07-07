﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TreeFactoryBusinessLogic.Enums;

namespace TreeFactoryDatabaseImplement.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int WoodId { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public decimal Sum { get; set; }

        [Required]
        public OrderStatus Status { get; set; }

        [Required]
        public DateTime DateCreate { get; set; }

        public DateTime? DateImplement { get; set; }

        public virtual Wood Wood { get; set; }
    }
}
