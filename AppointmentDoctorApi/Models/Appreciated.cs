using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models
{
    public class Appreciated
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [Display(Name = "Пользователь"), ForeignKey(nameof(User))]
        public long Fk_User { get; set; }
        [Required]
        [Display(Name = "Доктор"), ForeignKey(nameof(Doctor))]
        public long Fk_Doctor { get; set; }
        public int Assessment { get; set; }


        [JsonIgnore]
        public virtual Doctor Doctor { get; set; }
        [JsonIgnore]
        public virtual User User { get; set; }
    }
}
