using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DnuNavigator.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        // Quan hệ nhiều-nhiều với Subject qua bảng trung gian StudentSubject
        public ICollection<StudentSubject> StudentSubjects { get; set; } = new List<StudentSubject>();
    }
}