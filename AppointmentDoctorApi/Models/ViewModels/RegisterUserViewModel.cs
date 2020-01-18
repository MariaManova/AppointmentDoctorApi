using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required(ErrorMessage = "Введите имя пользователя"), Display(Name = "Имя")]
        public string FullName { get; set; }
        public string Address { get; set; }
        public int Gender { get; set; }
        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int Role { get; set; }

        public static explicit operator User(RegisterUserViewModel m)
        {
            return new User()
            {
                Email = m.Email,
                FullName = m.FullName,
                Enum_Gender = m.Gender,
                Enum_Role = m.Role,
                Removed = false,
            };
        }
    }
}
