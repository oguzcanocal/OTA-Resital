using RESITALMVC.CORE.Entity;
using RESITALMVC.MODEL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESITALMVC.MODEL.Entities
{
    public class User:CoreEntity
    {
        public User()
        {
            IsActive = false;
        }

        [Required(ErrorMessage="Kullanıcı adınızı giriniz.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Şifreniz uyumlu değil.")]
        public string ConfirmPassword { get; set; }
        [Required, EmailAddress(ErrorMessage = "Mail adresinizi giriniz.")]
        public string Email { get; set; }
        public Guid ActivationCode { get; set; }
        public bool IsActive { get; set; }
        [Display(Name ="Yetki")]
        public Role? Roles { get; set; }


    }
}
