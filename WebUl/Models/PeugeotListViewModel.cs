using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUl.Models
{
    public class PeugeotListViewModel
    {
        public IEnumerable<Peugeot> Peugeot { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}