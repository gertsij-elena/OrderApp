using System.ComponentModel.DataAnnotations;

namespace OrderApp.Models
{
    public class Product
    {
        [Key]
        [ScaffoldColumn(false)]
        public int ProductId { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле обязательно")]
        [StringLength(50, ErrorMessage = "Длина не должна превышать 50 символов")]
        public string Name { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Поле обязательно")]
        public decimal Price { get; set; }

        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Поле обязательно")]
        public int Count { get; set; }
    }
}