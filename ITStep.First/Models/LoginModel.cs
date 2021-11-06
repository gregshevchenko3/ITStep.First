using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ITStep.First.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Відсутній логін або електронна пошта")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Відсутній пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
