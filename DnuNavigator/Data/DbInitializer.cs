using DnuNavigator.Models;

namespace DnuNavigator.Data
{
    public static class DbInitializer
    {
        public static void Seed(ApplicationDbContext context)
        {
            // Nếu đã có dữ liệu học phần => không seed lại
            if (context.Subjects.Any() || context.Students.Any())
                return;

            // ✅ Danh sách học phần
            var subjects = new List<Subject>
            {
                new Subject
                {
                    SubjectName = "Cấu trúc dữ liệu & Giải thuật",
                    SubjectCode = "CTDLGT101",
                    Credits = 3,
                    Description = "Giới thiệu về cây, đồ thị, danh sách liên kết, đệ quy và giải thuật cơ bản.",
                    MaterialLink = "https://drive.google.com/file/d/1jw-ABC/view",
                    VideoLink = "https://www.youtube.com/watch?v=RBSGKlAvoiM"
                },
                new Subject
                {
                    SubjectName = "Cơ sở dữ liệu",
                    SubjectCode = "CSDL101",
                    Credits = 3,
                    Description = "Giới thiệu về hệ quản trị cơ sở dữ liệu, SQL, thiết kế cơ sở dữ liệu quan hệ.",
                    MaterialLink = "https://www.w3schools.com/sql/",
                    VideoLink = "https://www.youtube.com/watch?v=HXV3zeQKqGY"
                },
                new Subject
                {
                    SubjectName = "Nhập môn Lập trình",
                    SubjectCode = "NM_LP101",
                    Credits = 3,
                    Description = "Lập trình căn bản sử dụng C/C++, tư duy thuật toán, vòng lặp, điều kiện, hàm.",
                    MaterialLink = "https://github.com/angrave/SystemProgramming/wiki",
                    VideoLink = "https://www.youtube.com/watch?v=KJgsSFOSQv0"
                },
                new Subject
                {
                    SubjectName = "Hệ điều hành",
                    SubjectCode = "HDH101",
                    Credits = 3,
                    Description = "Các khái niệm về hệ điều hành, quản lý tiến trình, bộ nhớ, I/O.",
                    MaterialLink = "https://pages.cs.wisc.edu/~remzi/OSTEP/",
                    VideoLink = "https://www.youtube.com/watch?v=26QPDBe-NB8"
                },
                new Subject
                {
                    SubjectName = "Mạng máy tính",
                    SubjectCode = "MMT101",
                    Credits = 3,
                    Description = "Kiến trúc mạng, TCP/IP, định tuyến, tầng giao vận và ứng dụng.",
                    MaterialLink = "https://book.systemsapproach.org/",
                    VideoLink = "https://www.youtube.com/watch?v=3QhU9jd03a0"
                }
            };

            context.Subjects.AddRange(subjects);
            context.SaveChanges();

            // ✅ Danh sách sinh viên
            var students = new List<Student>
            {
                new Student { Email = "sv01@dainam.edu.vn", PasswordHash = "123456" },
                new Student { Email = "sv02@dainam.edu.vn", PasswordHash = "123456" },
                new Student { Email = "sv03@dainam.edu.vn", PasswordHash = "123456" }
            };

            context.Students.AddRange(students);
            context.SaveChanges();

            // ✅ Gán tất cả học phần cho từng sinh viên
            var studentSubjects = new List<StudentSubject>();
            foreach (var student in students)
            {
                foreach (var subject in subjects)
                {
                    studentSubjects.Add(new StudentSubject
                    {
                        StudentId = student.Id,
                        SubjectId = subject.Id
                    });
                }
            }

            context.StudentSubjects.AddRange(studentSubjects);
            context.SaveChanges();
        }
    }
}
