using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models.Helpers
{
    public class AppException : Exception
    {
        public AppException() { }
        public AppException(String message) : base(message)
        {

        }
    }
}
