﻿using System;

namespace DevLife.Web.Api.Commons.Services.Pagination
{
    public class PaginationParameters
    {
        private int _pageSize = 10;
        public int PageNumber { get; set; } = 1;

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > 50) ? 50 : value;
        }
    }
}