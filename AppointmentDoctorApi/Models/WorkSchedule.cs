using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppointmentDoctorApi.Models
{
    /// <summary>
    /// Рассписание работы
    /// </summary>
    public class WorkSchedule
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Доктор"), ForeignKey(nameof(Doctor))]
        public long Fk_Doctor { get; set; }
        [Display(Name = "Время приема")]
        public DateTime TimeReceipt { get; set; }
        public bool IsBusy { get; set; }

        [JsonIgnore]
        public virtual Doctor Doctor { get; set; }
    }
}