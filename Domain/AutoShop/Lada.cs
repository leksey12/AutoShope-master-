using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.AutoShop;
using System.Web.Mvc;
namespace Domain.AutoShop
{
    [Table("Lada")]
    public class Lada
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [DataType(DataType.MultilineText)]
        [Display(Name = "Модель")]
        public string Model { get; set; }
        [Display(Name = "Цена (руб)")]
        public decimal Price { get; set; }
    }
}
