using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUl.Models
{
    public class PorsheListViewModel
    {
        public IEnumerable<Porshe> Porshe { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}