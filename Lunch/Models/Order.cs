using System;
using System.ComponentModel.DataAnnotations;

namespace Lunch.Models
{
    public class Order
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "订餐时间必填")]
        [Display(Name = "订餐时间")]
        public DateTime OrderDate { get; set; }
        public DateTime CreateDate { get; set; }


        [Required(ErrorMessage = "商家名称必填")]
        [Display(Name = "商家名称")]
        public string BusinessName { get; set; }
        [Required(ErrorMessage = "菜品名称必填")]
        [Display(Name = "菜品名称")]
        public string DishName { get; set; }
        [Required(ErrorMessage = "价格必填")]
        [Display(Name = "价格")]
        [Range(1, int.MaxValue),]
        public double Price { get; set; }
        [Display(Name = "备注")]
        public string Remark { get; set; }
        [Display(Name = "是否付款")]
        public bool Ispay { get; set; }
    }
}