﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SportsStore.Web.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }

        public int CurrentPage { get; set; }

        public int ItemsPerPage { get; set; }

        public int TotalPagesCount => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}