using System;
using System.ComponentModel.DataAnnotations;

namespace Lunch.Models
{
    public class User
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "用户名必填")]
        [Display(Name = "用户名")]
        public string Name { get; set; }
        [Required(ErrorMessage = "密码必填")]
        [Display(Name = "密码")]
        public string Pwd { get; set; }
        [Display(Name = "真实姓名")]
        public string UserName { get; set; }
        [Display(Name = "注册时间")]
        public DateTime CreateTime { get; set; }
    }
}