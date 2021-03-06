﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models
{
    /// <summary>
    /// Запись к врачу
    /// </summary>
    public class Appointment
    {
        [Key]
        public long Id { get; set; }
        [Display(Name = "Доктор"), ForeignKey(nameof(Doctor))]
        public long Fk_Doctor { get; set; }
        [Display(Name = "Пациент"), ForeignKey(nameof(Patient))]
        public long Fk_Patient { get; set; }
        [Display(Name = "Дата и время приема")]
        public DateTime DateTimeReceipt  { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public bool Removed { get; set; }

        public virtual Doctor Doctor { get; set; }
        [JsonIgnore]
        public virtual Patient Patient { get; set; }
    }
}
