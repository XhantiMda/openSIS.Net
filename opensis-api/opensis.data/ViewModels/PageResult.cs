﻿using opensis.data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace opensis.data.Models
{
    public class PageResult: CommonFields
    {

        const int maxPageSize = 50;
        public int PageNumber { get; set; } = 1;

       // public string FilterText { get; set; }

        //public string SchoolNameFilter { get; set; }

        private int _pageSize = 10;
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
