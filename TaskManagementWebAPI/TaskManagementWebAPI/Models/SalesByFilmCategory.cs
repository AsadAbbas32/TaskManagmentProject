﻿using System;
using System.Collections.Generic;

namespace TaskManagementWebAPI.Models
{
    public partial class SalesByFilmCategory
    {
        public string Category { get; set; }
        public decimal? TotalSales { get; set; }
    }
}
