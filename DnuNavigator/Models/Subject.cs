using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DnuNavigator.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required]
        public string SubjectName { get; set; }

        public string? SubjectCode { get; set; }
        public int Credits { get; set; }
        public string? Description { get; set; }

        // ✅ Thêm thuộc tính mới
        public string? MaterialLink { get; set; }
        public string? VideoLink { get; set; }

        public ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}