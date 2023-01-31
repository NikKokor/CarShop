using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace CarShop.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name = "Имя")]
        [StringLength(20)]
        [Required(ErrorMessage = "Введите имя")]
        public string name { get; set; }

        [Display(Name = "Фамилия")]
        [StringLength(30)]
        [Required(ErrorMessage = "Введите фамилию")]
        public string surname { get; set; }

        [Display(Name = "Адрес")]
        [StringLength(100)]
        [Required(ErrorMessage = "Введите адрес")]
        public string adress { get; set; }

        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(18)]
        [Required(ErrorMessage = "Введите номер телефона")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(100)]
        [Required(ErrorMessage = "Введите email")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
