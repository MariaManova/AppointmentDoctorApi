using AppointmentDoctorApi.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AppointmentDoctorApi.Models.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext context;
        public UserService(AppDbContext context)
        {
            this.context = context;
        }

        public User Authenticate(string email, string password)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return null;

            var user = context.User.Include(p => p.Photo).FirstOrDefault(x => x.Email == email);

            // check if username exists and password is correct
            if (user == null || !VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public User Create(User user, string address, string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Необходим пароль");

            if (Get(u => u.Email == user.Email) != null)
                throw new AppException($"Пользователь с email {user.Email} уже существует.");

            CreatePasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.Fk_Photo = 2;

            context.Add(user);
            context.SaveChanges();

            Patient patient = new Patient();
            patient.Fk_User = user.Id;
            patient.Address = address;
            context.Add(patient);
            context.SaveChanges();

            return user;
        }
        public Patient Get(long Id)
        {
            try { return context.Patient.Where(u => u.Fk_User == Id).Single(); }
            catch { return null; }
        }
        public User Get(Func<User, bool> predicate)
        {
            try { return context.User.Where(predicate).Single(); }
            catch { return null; }
        }
        public void Update(User user)
        {
            if (!context.User.Any(x => x.Id == user.Id))
            {
                throw new AppException("Пользователь не найден");
            }
            context.Update(user);
            context.SaveChanges();
        }
        public void UpdateAuth(User user, string password = null)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            context.Remove(new User() { Id = id });
        }

        public IEnumerable<User> Fetch(Expression<Func<User, bool>> predicate)
        {
            return context.User.Where(predicate).Include(u => u.Photo);
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64)
                throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128)
                throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");
            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }
            return true;
        }
    }
}
