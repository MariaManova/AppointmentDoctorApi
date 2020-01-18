using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models
{
    /// <summary>
    /// Специальность
    /// </summary>
    public class Speciality
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Наименование специальности"), Column(TypeName = "Nvarchar(100)")]
        public String NameSpeciality { get; set; }
    }
}
