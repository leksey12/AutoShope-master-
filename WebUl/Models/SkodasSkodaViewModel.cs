using Domain.AutoShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Добавление данных модели представления
namespace WebUl.Models
{
    public class SkodasSkodaViewModel
    {
        public IEnumerable<Skoda> Skodas { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}