using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PasswordResetAPI.Models
{
    public class Operator
    {
        [DisplayName("Kullanıcı Adı")]
        [Required]
        public string userName { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("Ad Soyad")]
        public string name { get; set; }
    }
}