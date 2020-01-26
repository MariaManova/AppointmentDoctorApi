using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models.ViewModels
{
    public class AppointmentViewModel
    {
        public long Fk_Doctor { get; set; }
        public long Fk_Patient { get; set; }
        public DateTime DateTime { get; set; }

        public static explicit operator Appointment(AppointmentViewModel m)
        {
            return new Appointment()
            {
                Fk_Doctor = m.Fk_Doctor,
                Fk_Patient = m.Fk_Patient,
                DateTimeReceipt = m.DateTime,
                CreatedAt = DateTime.Now,
                EditedAt = DateTime.Now,
                Removed = false,
            };
        }
    }
}
