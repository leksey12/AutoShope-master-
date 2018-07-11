using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

//Создание класса модели данных
namespace Domain.AutoShop
{
    [Table("Autos")]
    public class Auto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       [Key]
        public int Id { get; set; }
        public string NAME { get; set; }
        public string ADRESS { get; set; }
        public string CITY { get; set; }
        public string TELEPHONE { get; set; }
        public string SITE { get; set; }
    }
}
