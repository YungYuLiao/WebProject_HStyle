﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace HStyleApi.Models.EFModels
{
    public partial class OrderDetail
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int UnitPrice { get; set; }
        public int SubTotal { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }

        public virtual Order Order { get; set; }
    }
}