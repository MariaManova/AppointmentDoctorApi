using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentDoctorApi.Models
{
    /// <summary>
    /// Место работы
    /// </summary>
    public class PlaceOfWork
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Наименование места рботы"), Column(TypeName = "Nvarchar(100)")]
        public String NamePlace { get; set; }
    }
}