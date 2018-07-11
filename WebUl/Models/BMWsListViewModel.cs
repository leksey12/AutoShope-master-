using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUl.Models
{
    public class BMWsListViewModel
    {
        public IEnumerable<BMW> BMWs { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}