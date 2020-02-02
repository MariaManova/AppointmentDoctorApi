using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models.ViewModels
{
    public class DoctorViewModel
    {
        public String FullName { get; set; }
        public String Email { get; set; }
        public long Fk_Speciality { get; set; }
        public long Fk_PlaceOfWork { get; set; }
        public int Enum_Category { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

        public static explicit operator User(DoctorViewModel m)
        {
            return new User()
            {
                FullName = m.FullName,
                Email = m.Email,
                Enum_Gender = 0,
                Enum_Role = 2,
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Removed = false,
            };
        }

        public static explicit operator Doctor(DoctorViewModel m)
        {
            return new Doctor()
            {
                Fk_Speciality = m.Fk_Speciality,
                Fk_PlaceOfWork = m.Fk_PlaceOfWork,
                Enum_Category = m.Enum_Category,
                Rating = 0,
                TotalSumRating = 0,
                NumRated = 0,
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Removed = false,
            };
        }
    }
}
