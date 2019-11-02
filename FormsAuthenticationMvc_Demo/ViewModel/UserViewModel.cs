using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormsAuthenticationMvc_Demo.ViewModel
{
    public class UserViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter username")]
        [Display(Name ="Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
    }
}