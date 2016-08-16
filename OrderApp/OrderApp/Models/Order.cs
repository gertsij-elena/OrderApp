using System.ComponentModel.DataAnnotations;

namespace OrderApp.Models
{
    public class Order
    {
        [Key]
        [ScaffoldColumn(false)]
        public int OrderId { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Поле обязательно")]
        [StringLength(50, ErrorMessage = "Длина не должна превышать 50 символов")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Поле обязательно")]
        [StringLength(50, ErrorMessage = "Длина не должна превышать 50 символов")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        [Display(Name = "Номер телефона")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        [Display(Name = "Адрес")]
        [StringLength(50, ErrorMessage = "Длина не должна превышать 50 символов")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        [Display(Name = "Дата добавления")]
        [DataType(DataType.DateTime)]
        public System.DateTime DateCreate { get; set; }

        [Display(Name = "Дата обновления")]
        [DataType(DataType.DateTime)]
        public System.DateTime DateAdd { get; set; }

        [Required(ErrorMessage = "Поле обязательно")]
        [Display(Name = "Сумма")]
        public decimal Summa { get; set; }

        //[Required(ErrorMessage = "Поле обязательно")]
        [Display(Name = "Архив")]
        public bool Old { get; set; }
    }
}