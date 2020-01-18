using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models.Services
{
    public interface IUserService
    {
        User Authenticate(string email, string password);
        IEnumerable<User> Fetch(Expression<Func<User, bool>> predicate);
        User Get(long id);
        User Get(Func<User, bool> predicate);
        User Create(User user, string password);
        void Update(User user);
        void UpdateAuth(User user, string password = null);
        void Delete(long id);
    }
}
